using KonusarakOgren.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KonusarakOgren.WebUI.Controllers
{
    [Route("Basket")]
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IPaymentService _paymentService;

        public BasketController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [Authorize(Roles = "SysAdmin,Customer")]
        [HttpGet("Basket")]
        public ActionResult Payment()
        {
            return View();
        }


        [Authorize(Roles = "SysAdmin,Customer")]
        [HttpPost("Basket")]
        public async Task<ActionResult> Payment(int basketId)
        {
            var result = await _paymentService.CreateOrPaymentIntent(basketId);
            return View(result);
        }
    }
}
