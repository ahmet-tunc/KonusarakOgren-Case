using Core.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace KonusarakOgren.Entities.Concrete
{
    public class Product:Entity
    {
        public Product()
        {
            ProductFeatures = new HashSet<ProductFeature>();
        }

        public string Name { get; set; }
        public string? Description { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public virtual ICollection<ProductFeature> ProductFeatures { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
