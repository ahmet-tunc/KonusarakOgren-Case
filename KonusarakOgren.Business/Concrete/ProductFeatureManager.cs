using KonusarakOgren.Business.Abstract;
using KonusarakOgren.Business.Concrete.Base;
using KonusarakOgren.DataAccess.Abstract;
using KonusarakOgren.Entities.Concrete;

namespace KonusarakOgren.Business.Concrete
{
    public class ProductFeatureManager : BaseManager<ProductFeature>, IProductFeatureService
    {
        private readonly IProductFeatureDal _productFeatureDal;

        public ProductFeatureManager(IProductFeatureDal productFeatureDal) : base(productFeatureDal)
        {
            _productFeatureDal = productFeatureDal;
        }
    }
}
