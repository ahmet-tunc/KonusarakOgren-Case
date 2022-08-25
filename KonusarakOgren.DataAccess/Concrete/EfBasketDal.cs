using Core.DataAccess.EntityFramework;
using KonusarakOgren.DataAccess.Abstract;
using KonusarakOgren.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace KonusarakOgren.DataAccess.Concrete
{
    public class EfBasketDal: EfEntityRepositoryBase<Basket, AppDbContext>, IBasketDal
    {
    }
}
