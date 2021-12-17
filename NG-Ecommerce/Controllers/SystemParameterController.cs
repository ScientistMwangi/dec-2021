using AutoMapper;
using EcommerceCore.DataLayer;
using EcommerceCore.DataLayer.Repository;
using EcommerceCore.Models;
using EcommerceCore.Models.Users;
using EcommerceCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NG_Ecommerce.Helpers;
using NG_Ecommerce.Models;
using NG_Ecommerce.Models.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NG_Ecommerce.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/system-configs")]
    public class SystemParameterController : ControllerBase
    {
        private readonly EcommerceDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductCategoryRepo _productCategoryRepo;
        private readonly IProductTagRepo _productTagRepo;
        private readonly IProductRepo _productRepo;
        private readonly IOrderService _orderService;
        private readonly IWebHostEnvironment _env;

        public SystemParameterController(IWebHostEnvironment env, EcommerceDbContext context, IMapper mapper, UserManager<AppUser> userManager, IUnitOfWork unitOfWork,
            IProductCategoryRepo productCategoryRepo, IProductTagRepo productTagRepo, IProductRepo productRepo, IOrderService orderService)
        {
            _env = env;
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _productTagRepo = productTagRepo;
            _productCategoryRepo = productCategoryRepo;
            _productRepo = productRepo;

            _orderService = orderService;
        }

       
        [HttpGet("get-category")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = _context.ProductCategories.ToList();
            return Ok(categories);
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("add-category")]
        public async Task<IActionResult> AddCategories([FromBody] ProductCategory productCategory)
        {
            GenericResponse<ProductCategory> response = new GenericResponse<ProductCategory>();

            var user = await _userManager.GetUserAsync(User);
            productCategory.DateCreated = DateTime.Now;
            productCategory.CreatedBy = user.UserName;

            var exist = _productCategoryRepo.FindEntity(x => x.Name.ToLower() == productCategory.Name.ToLower());

            if (!ModelState.IsValid || exist != null)
            {
                response.Success = false;
                response.Message = exist == null ? "Please provide correct information" :" Item exist";
                response.ReponseObject = productCategory;
                return Ok(response);
            }
             
            _productCategoryRepo.Add(productCategory);
            await _unitOfWork.Complete();
            response.Success = true;
            response.Message = "Category added successfully";
            response.ReponseObject = productCategory;
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("edit-category")]
        public async Task<IActionResult> Editategories([FromBody] ProductCategory productCategory)
        {
            GenericResponse<ProductCategory> response = new GenericResponse<ProductCategory>();
            var user = await _userManager.GetUserAsync(User);

            if (!ModelState.IsValid)
            {
                response.Success = false;
                response.ReponseObject = productCategory;
                response.Message = "Please provide correct information";
                return Ok(response);
            }
                
            var existing = _productCategoryRepo.GetById(productCategory.Id);
            if (existing == null)
            {
                response.Success = false;
                response.ReponseObject = productCategory;
                response.Message = "Product category does not exist";
                return Ok(response);
            }
            // Minimize this coding part? automapper?
            existing.DateLastModified = DateTime.Now;
            existing.LastModifiedBy = user.UserName;
            existing.Name = productCategory.Name;
            existing.Description = productCategory.Description;
            _productCategoryRepo.Update(existing);
            await _unitOfWork.Complete();

            response.Success = true;
            response.Message = "Category added successfully";
            response.ReponseObject = productCategory;
            return Ok(response);
        }

        [HttpGet("get-tags")]
        public async Task<IActionResult> GetTags()
        {
            var tags = _context.ProductTags.ToList();
            return Ok(tags);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add-tag")]
        public async Task<IActionResult> AddTag([FromBody] ProductTag productTag)
        {
            GenericResponse<ProductTag> response = new GenericResponse<ProductTag>();
            response.ReponseObject = productTag;

            var user = await _userManager.GetUserAsync(User);
            productTag.DateCreated = DateTime.Now;
            productTag.CreatedBy = user.UserName;

            var exist = _productTagRepo.FindEntity(x => x.Name.ToLower() == productTag.Name.ToLower());

            if (!ModelState.IsValid || exist != null)
            {
                response.Success = false;
                response.Message = exist == null ? "Please provide correct information" : " Item exist";
                return Ok(response);
            }
                
            _productTagRepo.Add(productTag);
            await _unitOfWork.Complete();

            response.Success = true;
            response.Message = "Tag added successfully";
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("edit-tag")]
        public async Task<IActionResult> EditTag([FromBody] ProductTag productTag)
        {
            GenericResponse<ProductTag> response = new GenericResponse<ProductTag>();
            response.ReponseObject = productTag;
            var user = await _userManager.GetUserAsync(User);

            if (!ModelState.IsValid)
            {
                response.Success = false;
                response.Message = "Invalid object";
                return Ok(response);
            }
            var existing = _productTagRepo.GetById(productTag.Id);
            if (existing == null)
            {
                response.Success = false;
                response.Message = "Product tag doesnot exist";
                return Ok(response);
            }
            existing.DateLastModified = DateTime.Now;
            existing.LastModifiedBy = user.UserName;
            existing.Name = productTag.Name;
            existing.Description = productTag.Description;
            _productTagRepo.Update(existing);
            await _unitOfWork.Complete();


            response.Success = true;
            response.Message = "Update successfully";
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add-product"), DisableRequestSizeLimit]
        public async Task<IActionResult> AddProduct([FromForm] Product product)
        {
            /*var product = new Product();
            product.Name = prod.Name;
            product.ProductTags = prod.ProductTags;
            product.ProductCategoryId = prod.ProductCategoryId;
            product.PricePerItem = (decimal)prod.PricePerItem;
            product.Quantity = (decimal)prod.Quantity;
            product.ImageUrl = prod.ImageUrl;*/
            product.ImageUrl = "url";
            GenericResponse<Product> response = new GenericResponse<Product>();
            response.ReponseObject = product;

            var user = await _userManager.GetUserAsync(User);
            product.DateCreated = DateTime.Now;
            product.CreatedBy = user.UserName;

            var exist = _productRepo.FindEntity(x => x.Name.ToLower() == product.Name.ToLower());
            if (!ModelState.IsValid || exist != null)
            {
                response.ReponseObject.FormFile = null;
                response.Success = false;
                response.Message = exist == null ? "Please provide correct information" : " Item exist";
                return Ok(response);
            }

            string semiPath = string.Empty;
            string fileName = "";
            if (product.FormFile != null)
            {
                fileName = $"img_{Guid.NewGuid()}_{product.FormFile.FileName}";
                semiPath = $"\\public\\assests\\";
                var rootPath = _env.ContentRootPath + semiPath+fileName;
                var path = Path.Combine(rootPath, $"{semiPath}", fileName);
                using (var stream = new FileStream(rootPath, FileMode.Create))
                {
                     await product.FormFile.CopyToAsync(stream);
                }
            }
            product.ImageUrl = fileName;
            _productRepo.Add(product);
            await _unitOfWork.Complete();

            // Json serial issue remove the file
            response.ReponseObject.FormFile = null;
            response.Success = true;
            response.Message = " Added successfully";
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("edit-product")]
        public async Task<IActionResult> EditProduct([FromBody] Product product)
        {
            GenericResponse<Product> response = new GenericResponse<Product>();
            response.ReponseObject = product;
            var user = await _userManager.GetUserAsync(User);

            if (!ModelState.IsValid)
            {
                response.Success = false;
                response.Message = " Invalid object";
                return Ok(response);
            }
            var existing = _productRepo.GetById(product.Id);
            if (existing == null)
            {
                response.Success = false;
                response.Message = "Product does not exist";
                return Ok(response);
            }


            // Minimize this code
            existing.DateLastModified = DateTime.Now;
            existing.LastModifiedBy = user.UserName;
            existing.ProductTags = product.ProductTags;
            existing.ProductCategoryId = product.ProductCategoryId;
            existing.Name = product.Name;
            existing.ImageUrl = product.ImageUrl;
            existing.Description = product.Description;
            existing.Quantity = product.Quantity;
            existing.PricePerItem = product.PricePerItem;

            _productRepo.Update(existing);
            await _unitOfWork.Complete();
            response.Success = true;
            response.Message = " Product updated successfully";
            return Ok(response);
        }


        [HttpGet("get-products-params")]
        public async Task<IActionResult> GetProductsParameters()
        {

            return Ok(_orderService.GetProductSummary());
        }

        [AllowAnonymous]
        [HttpGet("get-products")]
        public async Task<IActionResult> GetProducts(int page =1, int pageSize = 6)
        {
            var products = _context.Products.GetPaged<Product>(page, pageSize);

            var res = new List<List<Product>>();

            int count = products.Results.Count;
            if(count <= 3)
            {
                var subList = new List<Product>();
                foreach(var p in products.Results)
                {
                    subList.Add(p);

                }
                res.Add(subList);

            }
            else
            {
                int c = 0;
                var subList = new List<Product>();
                foreach (var p in products.Results)
                {
                    if(c == 3)
                    {
                        res.Add(subList);
                        subList = new List<Product>();
                    }
                        
                    subList.Add(p);
                    c += 1;

                }
                res.Add(subList);
            }

            products.Results2 = res;

            return Ok(products);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("get-email-logs")]
        public async Task<IActionResult> GetEmailLogs(int page = 1, int pageSize = 50)
        {
            var logs = _context.EmailLogs.GetPaged<EmailLog>(page, pageSize);
            return Ok(logs);
        }
    }
}
