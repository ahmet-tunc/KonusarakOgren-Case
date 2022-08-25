using AutoMapper;
using KonusarakOgren.Business.Abstract;
using KonusarakOgren.WebAPI.Controllers.Base;
using KonusarakOgren.Entities.Concrete;
using KonusarakOgren.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace KonusarakOgren.WebUI.Controllers
{
    [Route("Brand")]
    [Authorize(Roles = "SysAdmin,Admin")]
    public class BrandController : BaseController<Brand,BrandModel>
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;
        public BrandController(IBrandService brandService, IMapper mapper) : base(brandService,mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }
    }
}
