using Core.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace KonusarakOgren.Entities.Concrete
{
    public class ProductFeature:Entity
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public int? ProductDiscountId { get; set; }
        public ProductDiscount? ProductDiscount { get; set; }
        public bool ApplyDiscount { get; set; } = false;

        public int? ColorFeatureId { get; set; }
        public ProductColorFeature? ColorFeature { get; set; }


        public int? PyshicalFeatureId { get; set; }
        public ProductPhysicalFeature? PyshicalFeature { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
