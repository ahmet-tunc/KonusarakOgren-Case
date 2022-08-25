using Core.DataAccess.EntityFramework;
using KonusarakOgren.DataAccess.Abstract;
using KonusarakOgren.Entities.Concrete;

namespace KonusarakOgren.DataAccess.Concrete
{
    public class EfProductFeatureDal : EfEntityRepositoryBase<ProductFeature, AppDbContext>, IProductFeatureDal
    {
    }
}
