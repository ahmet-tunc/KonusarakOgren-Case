using Core.DataAccess.EntityFramework;
using KonusarakOgren.DataAccess.Abstract;
using KonusarakOgren.Entities.Concrete;

namespace KonusarakOgren.DataAccess.Concrete
{
    public class EfProductDal: EfEntityRepositoryBase<Product, AppDbContext>, IProductDal
    {
    }
}
