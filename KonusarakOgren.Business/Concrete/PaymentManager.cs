using KonusarakOgren.Entities.Concrete;
using Stripe;
using Microsoft.Extensions.Configuration;
using KonusarakOgren.Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;

namespace KonusarakOgren.Business.Concrete
{
    public class PaymentManager:IPaymentService
    {
        private readonly IConfiguration _config;
        private readonly IBasketService _basketService;

        public PaymentManager(IConfiguration config, IBasketService basketService)
        {
            _config = config;
            _basketService = basketService;
        }

        public async Task<IDataResult<Basket>> CreateOrPaymentIntent(int basketId)
        {
            StripeConfiguration.ApiKey = _config["StripeSettings:SecretKey"];

            //Yetişmedi.

            return new SuccessDataResult<Basket>();
        }
    }
}
