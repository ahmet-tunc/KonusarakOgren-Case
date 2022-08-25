using Autofac;
using Autofac.Extras.DynamicProxy;
using KonusarakOgren.Business.Abstract;
using KonusarakOgren.Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors.Autofac;
using KonusarakOgren.DataAccess.Abstract;
using KonusarakOgren.DataAccess.Concrete;

namespace KonusarakOgren.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BrandManager>().As<IBrandService>();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>();

            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<ProductFeatureManager>().As<IProductFeatureService>();
            builder.RegisterType<EfProductFeatureDal>().As<IProductFeatureDal>();

            builder.RegisterType<ProductColorFeatureManager>().As<IProductColorFeatureService>();
            builder.RegisterType<EfProductColorFeatureDal>().As<IProductColorFeatureDal>();

            builder.RegisterType<ProductPhysicalFeatureManager>().As<IProductPhysicalFeatureService>();
            builder.RegisterType<EfProductPhysicalFeatureDal>().As<IProductPhysicalFeatureDal>();

            builder.RegisterType<ProductCommentManager>().As<IProductCommentService>();
            builder.RegisterType<EfProductCommentDal>().As<IProductCommentDal>();

            builder.RegisterType<ProductDiscountManager>().As<IProductDiscountService>();
            builder.RegisterType<EfProductDiscountDal>().As<IProductDiscountDal>();

            builder.RegisterType<BasketManager>().As<IBasketService>();
            builder.RegisterType<EfBasketDal>().As<IBasketDal>();

            builder.RegisterType<PaymentManager>().As<IPaymentService>();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions() 
                { 
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
