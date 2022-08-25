using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using KonusarakOgren.Business.Abstract;
using KonusarakOgren.Business.Concrete.Base;
using KonusarakOgren.DataAccess.Abstract;
using KonusarakOgren.Entities.Concrete;

namespace KonusarakOgren.Business.Concrete
{
    public class BasketManager : BaseManager<Basket>, IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal):base(basketDal)
        {
            _basketDal = basketDal;
        }

        public async Task<IResult> DeleteBasketAsync(int basketId)
        {
            return await _basketDal.DeleteByIdAsync(x=>x.Id == basketId);
        }

        public async Task<IDataResult<Basket>> GetBasketAsync(int basketId)
        {
            return await _basketDal.GetAsync(x=>x.Id == basketId);
        }


        public async Task<IDataResult<Basket>> UpdateBasketAsync(Basket basket)
        {
            var result = await _basketDal.UpdateAsync(basket);
            if (!result.Success)
                return new ErrorDataResult<Basket>(result.Message);

            return new SuccessDataResult<Basket>(result.Message);
        }
    }
}
