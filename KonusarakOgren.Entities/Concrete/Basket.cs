using Core.Entities.Concrete;

namespace KonusarakOgren.Entities.Concrete
{
    public class Basket:Entity
    {
        public int UserId { get; set; }
        public AppUser User { get; set; }

        public List<BasketItem> Baskets { get; set; }

        public int TotalPrice { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
