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
    [Authorize(Roles = "SysAdmin,Customer")]
    public class CommentController : BaseController<ProductComment,ProductCommentModel>
    {
        private readonly IProductCommentService _productCommentService;
        private readonly IMapper _mapper;
        public CommentController(IProductCommentService productCommentService, IMapper mapper) : base(productCommentService, mapper)
        {
            _productCommentService = productCommentService;
            _mapper = mapper;
        }
    }
}
