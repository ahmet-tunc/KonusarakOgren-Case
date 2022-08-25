using KonusarakOgren.Business.Abstract;
using KonusarakOgren.Business.Concrete.Base;
using KonusarakOgren.DataAccess.Abstract;
using KonusarakOgren.Entities.Concrete;

namespace KonusarakOgren.Business.Concrete
{
    public class ProductCommentManager : BaseManager<ProductComment>, IProductCommentService
    {
        private readonly IProductCommentDal _productCommentDal;

        public ProductCommentManager(IProductCommentDal productCommentDal) : base(productCommentDal)
        {
            _productCommentDal = productCommentDal;
        }
    }
}
