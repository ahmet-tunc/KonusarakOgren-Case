using Core.Entities.Concrete;

namespace KonusarakOgren.Entities.Concrete
{
    public class ProductColorFeature:Entity
    {
        public string? PrimaryColor { get; set; }
        public string? SecondaryColor { get; set; }
    }
}