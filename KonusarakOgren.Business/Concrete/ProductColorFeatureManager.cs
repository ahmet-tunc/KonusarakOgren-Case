using KonusarakOgren.Business.Abstract;
using KonusarakOgren.Business.Concrete.Base;
using KonusarakOgren.DataAccess.Abstract;
using KonusarakOgren.Entities.Concrete;

namespace KonusarakOgren.Business.Concrete
{
    public class ProductColorFeatureManager : BaseManager<ProductColorFeature>, IProductColorFeatureService
    {
        private readonly IProductColorFeatureDal _productColorFeatureDal;

        public ProductColorFeatureManager(IProductColorFeatureDal productColorFeatureDal) : base(productColorFeatureDal)
        {
            _productColorFeatureDal = productColorFeatureDal;
        }
    }
}
