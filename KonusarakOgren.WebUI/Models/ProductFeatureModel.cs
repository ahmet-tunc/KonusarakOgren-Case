using Core.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace KonusarakOgren.WebUI.Models
{
    public class ProductFeatureModel:Entity
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public int? ProductDiscountId { get; set; }
        public ProductDiscountModel? ProductDiscount { get; set; }
        public bool ApplyDiscount { get; set; } = false;

        public int? ColorFeatureId { get; set; }
        public ProductColorFeatureModel? ColorFeature { get; set; }


        public int? PyshicalFeatureId { get; set; }
        public ProductPhysicalFeatureModel? PyshicalFeature { get; set; }

        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
    }
}
