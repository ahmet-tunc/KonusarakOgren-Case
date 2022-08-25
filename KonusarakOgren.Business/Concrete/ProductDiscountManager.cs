using KonusarakOgren.Business.Abstract;
using KonusarakOgren.Business.Concrete.Base;
using KonusarakOgren.DataAccess.Abstract;
using KonusarakOgren.Entities.Concrete;

namespace KonusarakOgren.Business.Concrete
{
    public class ProductDiscountManager : BaseManager<ProductDiscount>, IProductDiscountService
    {
        private readonly IProductDiscountDal _productDiscountDal;

        public ProductDiscountManager(IProductDiscountDal productDiscountDal) : base(productDiscountDal)
        {
            _productDiscountDal = productDiscountDal;
        }
    }
}
