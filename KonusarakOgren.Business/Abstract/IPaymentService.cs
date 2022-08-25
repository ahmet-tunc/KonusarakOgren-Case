using Core.Utilities.Results.Abstract;
using KonusarakOgren.Entities.Concrete;

namespace KonusarakOgren.Business.Abstract
{
    public interface IPaymentService
    {
        Task<IDataResult<Basket>> CreateOrPaymentIntent(int basketId);
    }
}
