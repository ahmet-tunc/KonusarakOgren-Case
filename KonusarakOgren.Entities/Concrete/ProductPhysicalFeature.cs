using Core.Entities.Concrete;

namespace KonusarakOgren.Entities.Concrete
{
    public class ProductPhysicalFeature:Entity
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Weight { get; set; }
        public int ProductId { get; set; }
    }
}