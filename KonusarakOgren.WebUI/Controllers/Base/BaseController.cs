using AutoMapper;
using Core.Entities.Concrete;
using KonusarakOgren.Business.Abstract.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KonusarakOgren.WebAPI.Controllers.Base
{
    [Route("[controller]")]
    [Authorize]
    public abstract class BaseController<T,TModel> : Controller
        where T : Entity, new()
    {
        private readonly IBaseService<T> _baseService;
        private readonly IMapper _mapper;
        public BaseController(IBaseService<T> baseService, IMapper mapper)
        {
            _baseService = baseService;
            _mapper = mapper;
        }


        [HttpGet("Index")]
        public virtual async Task<IActionResult> Index()
        {
            var result = await _baseService.GetAllAsync();
            if (result.Success)
            {
                return View(_mapper.Map<List<TModel>>(result.Data));
            }
            return View(result);
        }

        [HttpPost("Get")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var result = await _baseService.GetByIdAsync(id);
            if (result.Success)
            {
                return View(_mapper.Map<T>(result.Data));
            }
            return RedirectToAction("Index","Home");
        }

        [HttpGet("Add")]
        public virtual IActionResult Add()
        {
            return View();
        }

        [HttpPost("Add")]
        public virtual async Task<IActionResult> Add(TModel entity)
        {
            var result = await _baseService.AddAsync(_mapper.Map<T>(entity));
            if (result.Success)
            {
                return View(result);
            }
            return View(entity);
        }

        [HttpGet("Update")]
        public virtual IActionResult Update()
        {
            return View();
        }

        [HttpPost("Update")]
        public virtual async Task<IActionResult> Update(TModel entity)
        {
            var result = await _baseService.UpdateAsync(_mapper.Map<T>(entity));
            if (result.Success)
            {
                return View(result);
            }
            return View(entity);
        }
    }
}
