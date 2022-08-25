using KonusarakOgren.Business.Abstract;
using KonusarakOgren.Business.Concrete.Base;
using KonusarakOgren.DataAccess.Abstract;
using KonusarakOgren.Entities.Concrete;

namespace KonusarakOgren.Business.Concrete
{
    public class ProductPhysicalFeatureManager : BaseManager<ProductPhysicalFeature>, IProductPhysicalFeatureService
    {
        private readonly IProductPhysicalFeatureDal _productPhysicalFeatureDal;

        public ProductPhysicalFeatureManager(IProductPhysicalFeatureDal productPhysicalFeatureDal) : base(productPhysicalFeatureDal)
        {
            _productPhysicalFeatureDal = productPhysicalFeatureDal;
        }
    }
}
