using AutoMapper;
using KonusarakOgren.Business.Abstract;
using KonusarakOgren.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace KonusarakOgren.WebUI.Controllers
{
    [Authorize]
    [Route("Home")]
    [Authorize(Roles = "SysAdmin,Admin,Customer")]
    public class HomeController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public HomeController(IBrandService brandService, IProductService productService, IMapper mapper)
        {
            _brandService = brandService;
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index(int brandId = 0)
        {
            var brandList = await _brandService.GetAllAsync();
            var productList = await _productService.GetAllAsync(brandId != 0 ? x => x.BrandId == brandId : null);

            var roles = String.Join(',',((ClaimsIdentity)User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value).ToArray());

            var model = new HomePageViewModel
            {
                Brands = _mapper.Map<List<BrandModel>>(brandList.Data), //SelectListItem olarakta gönderilebilirdi. Bu sayede currentBrandId'ye gerek kalmazdı
                Products = _mapper.Map<List<ProductModel>>(productList.Data),
                CurrentBrandId = brandId,
                Roles = roles
            };
            return View(model);
        }
    }
}