namespace KonusarakOgren.WebUI.Models
{
    public class HomePageViewModel
    {
        public List<BrandModel> Brands { get; set; }
        public List<ProductModel> Products { get; set; }
        public int CurrentBrandId { get; set; } = 0;
        public string Roles { get; set; }
    }
}
