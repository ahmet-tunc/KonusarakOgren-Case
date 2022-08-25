using Core.Entities.Concrete;

namespace KonusarakOgren.Entities.Concrete
{
    public class Brand:Entity
    {
        public string? Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
