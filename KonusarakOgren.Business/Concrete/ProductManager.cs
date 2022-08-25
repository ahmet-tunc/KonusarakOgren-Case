using KonusarakOgren.Business.Abstract;
using KonusarakOgren.Business.Concrete.Base;
using KonusarakOgren.DataAccess.Abstract;
using KonusarakOgren.Entities.Concrete;

namespace KonusarakOgren.Business.Concrete
{
    public class ProductManager : BaseManager<Product>, IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal) : base(productDal)
        {
            _productDal = productDal;
        }
    }
}
