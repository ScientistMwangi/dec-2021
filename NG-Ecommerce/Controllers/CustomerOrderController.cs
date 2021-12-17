using AutoMapper;
using EcommerceCore.DataLayer;
using EcommerceCore.Dto;
using EcommerceCore.Models;
using EcommerceCore.Models.Users;
using EcommerceCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NG_Ecommerce.Helpers;
using NG_Ecommerce.Models;
using NG_Ecommerce.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NG_Ecommerce.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/order")]
    public class CustomerOrderController : ControllerBase
    {
        private readonly EcommerceDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;
        public CustomerOrderController(EcommerceDbContext context, IMapper mapper, UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IOrderService orderService)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _orderService = orderService;
        }

        [HttpGet("my-orders")]
        public async Task<IActionResult> GetMyOrders()
        {
            var user = await _userManager.GetUserAsync(User);
            var res = _orderService.GetCustomerOrders(user);
            return Ok(res);
        }

        [HttpPost("confirm-order")]
        public async Task<IActionResult> ConfirmOrder([FromBody] List<OrderOfProductsDto> products)
        {
            GenericResponse<List<OrderOfProductsDto>> response = new GenericResponse<List<OrderOfProductsDto>>();
            response.ReponseObject = products;
            var user = await _userManager.GetUserAsync(User);
            if (!ModelState.IsValid)
            {
                response.Message = "Invalid inputs";
                response.Success = false;
                return Ok(response);
            }

            try
            {
                decimal totalCost = 0;
                foreach (var prod in products)
                {
                    totalCost += (prod.Quantity * prod.PricePerItem);
                    var productExist = _orderService.ProductExist(prod.Id, prod.Quantity);
                    if (!productExist)
                    {
                        response.Message = "Product does not exist";
                        response.Success = false;
                        return Ok(response);
                    }
                        
                }
               var savedCustomerOrder =  _orderService.MakeOrder(user, products, totalCost);

                // send an email
                var emailTemplate = _context.EmailTemplates.Where( et => et.TemplateType == EcommerceConstants.EmailTemplateType.SendOrder).FirstOrDefault();
                var body = emailTemplate.EmailBody;
                var subject = emailTemplate.Subject + " " + savedCustomerOrder.Id;
                var rows = "";
                var purchasedItems = emailTemplate.PurchasedItems;
                foreach (var product in products)
                {
                    rows += string.Format(purchasedItems, product.Name, product.Quantity, product.PricePerItem);
                }
                string emailBody = body.Replace(Util.ORDERNUMBER.ToString(), savedCustomerOrder.Id.ToString())
                      .Replace(Util.ORDERDATE, DateTime.Now.ToString("ddd, dd MMM yyy"))
                      .Replace(Util.PURCHASEDITEMS, rows).Replace(Util.TOTALCOST, totalCost.ToString());
                EmailOperations.EmailSend(_context, user.Email, subject, emailBody);

                response.Success = true;
                response.Message = "Order confirmed";
                return Ok(response);
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.Success = false;
                return Ok(response);
            }
        }
    }
}
