using KonusarakOgren.Business.Abstract;
using KonusarakOgren.Business.Concrete.Base;
using KonusarakOgren.DataAccess.Abstract;
using KonusarakOgren.Entities.Concrete;

namespace KonusarakOgren.Business.Concrete
{
    public class BrandManager : BaseManager<Brand>, IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal) : base(brandDal)
        {
            _brandDal = brandDal;
        }
    }
}
