using AutoMapper;
using KonusarakOgren.Business.Abstract;
using KonusarakOgren.WebAPI.Controllers.Base;
using KonusarakOgren.Entities.Concrete;
using KonusarakOgren.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KonusarakOgren.WebUI.Controllers
{
    [Authorize(Roles = "SysAdmin,Admin")]
    [Route("Product")]
    public class ProductController : BaseController<Product, ProductModel>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper) : base(productService,mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

    }
}
