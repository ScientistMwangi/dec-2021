using AutoMapper;
using EcommerceCore.DataLayer;
using EcommerceCore.Dto;
using EcommerceCore.Models;
using EcommerceCore.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCore.Services
{
    public interface IOrderService
    {
        List<ProductParamsDto> GetProductSummary();
        MyOrdersDto GetCustomerOrders(AppUser user);
        CustomerOrder MakeOrder(AppUser user, List<OrderOfProductsDto> product, decimal totalPrice);
        /// <summary>
        /// Can use a view or sp
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        bool ProductExist(int productId, decimal orderedQuantity);
        decimal SoldItems(int productId);
    }
    public class OrderService : IOrderService
    {
        private readonly EcommerceDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(EcommerceDbContext context, IMapper mapper, UserManager<AppUser> userManager, IUnitOfWork unitOfWork)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }
        public MyOrdersDto GetCustomerOrders(AppUser user)
        {

            var orders = _context.CustomerOrders.Where(o => o.UserId.Equals(user.Id)).AsQueryable();
            var oderDetails = (from prod in _context.Products
                               from order in orders
                               from orderDetails in _context.CustomerOrderDetails.Where(o => o.ProductId == prod.Id && o.CustomerOrderId == order.Id)
                               select (new MyOrderDetails
                               {
                                   ImageUrl = prod.ImageUrl,
                                   PricePerItem = prod.PricePerItem,
                                   Quantity = orderDetails.Quantity,
                                   Name = prod.Name,
                                   OrderDate = order.DateCreated
                               })).ToList();

            MyOrdersDto myOrdersDto = new MyOrdersDto();
            myOrdersDto.Orders = orders.ToList();
            myOrdersDto.ListOfMyOrderDetails = oderDetails;

            return myOrdersDto;
        }

        public CustomerOrder MakeOrder(AppUser user, List<OrderOfProductsDto> products, decimal totalCost)
        {
            List<CustomerOrderDetail> orderDetails = new List<CustomerOrderDetail>();
            var order = new CustomerOrder { UserId = user.Id, TotalCost = totalCost, CreatedBy = user.UserName, DateCreated = DateTime.Now };
            _context.CustomerOrders.Add(order);
            _context.SaveChanges();

            foreach (var prod in products)
            {
                var od = new CustomerOrderDetail { CustomerOrderId = order.Id, ProductId = prod.Id, Quantity = prod.Quantity };
                orderDetails.Add(od);
            }
            _context.CustomerOrderDetails.AddRange(orderDetails);
            _context.SaveChanges();
            return order;
        }

        public bool ProductExist(int productId, decimal orderedQuantity)
        {
            var total = _context.Products.Where(p => p.Id == productId).FirstOrDefault().Quantity;
            decimal alreadyBoughtQuantity = SoldItems(productId);


            alreadyBoughtQuantity += orderedQuantity;
            if (alreadyBoughtQuantity > total)
                return false;
            return true;
        }
        public List<ProductParamsDto>GetProductSummary()
        {
            var res = (from product in _context.Products
                       from category in _context.ProductCategories.Where(c => c.Id == product.ProductCategoryId)
                       select new ProductParamsDto
                       {
                           Id = product.Id,
                           Category = category.Name,
                           Name = product.Name,
                           CategoryId = category.Id,
                           Description = product.Description,
                           PricePerItem = product.PricePerItem,
                           Quantity = product.Quantity,
                           SoldOut = (_context.CustomerOrderDetails.Where(o => o.ProductId == product.Id)).Count()
                       }).ToList();
            return res;

        }

        public decimal SoldItems(int productId)
        {
            decimal alreadyBoughtQuantity = 0;
            var hasBeenOrdered = _context.CustomerOrderDetails.Where(ord => ord.ProductId == productId).FirstOrDefault();
            if (hasBeenOrdered == null)
            {
                alreadyBoughtQuantity = 0;
            }
            else
            {
                var query = string.Format("select sum(Quantity) as Quantity, max(id) as Id, max(CustomerOrderId)as CustomerOrderId, max(ProductId) as ProductId from CustomerOrderDetail  where productid= {0}", productId);
                var sumOfProductBought = _context.CustomerOrderDetails.FromSqlRaw(query)?.FirstOrDefault();
                alreadyBoughtQuantity = sumOfProductBought.Quantity;
            }
            return alreadyBoughtQuantity;
        }
    }
}
