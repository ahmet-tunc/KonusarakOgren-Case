using AutoMapper;
using KonusarakOgren.Entities.Concrete;
using KonusarakOgren.WebUI.Models;

namespace KonusarakOgren.WebUI.Mapping
{
    public class AppProfile:Profile
    {
        public AppProfile()
        {
            CreateMap<Brand, BrandModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureModel>().ReverseMap();
            CreateMap<ProductPhysicalFeature, ProductPhysicalFeatureModel>().ReverseMap();
            CreateMap<ProductColorFeature, ProductColorFeatureModel>().ReverseMap();
            CreateMap<ProductDiscount, ProductDiscountModel>().ReverseMap();
            CreateMap<ProductComment, ProductCommentModel>().ReverseMap();
            CreateMap<Basket, BasketModel>().ReverseMap();
            CreateMap<BasketItem, BasketItemModel>().ReverseMap();
        }
    }
}
