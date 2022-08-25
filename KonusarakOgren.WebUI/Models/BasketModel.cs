using Core.Entities.Concrete;

namespace KonusarakOgren.WebUI.Models
{
    public class BasketModel : Entity
    {
        public int UserId { get; set; }

        public List<BasketItemModel> Baskets { get; set; }

        public int TotalPrice { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
