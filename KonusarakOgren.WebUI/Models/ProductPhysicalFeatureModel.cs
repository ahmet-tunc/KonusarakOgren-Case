using Core.Entities.Concrete;

namespace KonusarakOgren.WebUI.Models
{
    public class ProductPhysicalFeatureModel:Entity
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Weight { get; set; }
        public int ProductId { get; set; }
    }
}