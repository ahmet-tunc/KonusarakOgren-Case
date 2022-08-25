using Core.Utilities.Results.Abstract;
using KonusarakOgren.Business.Abstract.Base;
using KonusarakOgren.Entities.Concrete;

namespace KonusarakOgren.Business.Abstract
{
    public interface IBasketService : IBaseService<Basket>
    {
        Task<IDataResult<Basket>> GetBasketAsync(int basketId);
        Task<IDataResult<Basket>> UpdateBasketAsync(Basket basket);
        Task<IResult> DeleteBasketAsync(int basketId);
    }
}
