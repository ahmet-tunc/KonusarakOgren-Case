using Core.Entities.Concrete;

namespace KonusarakOgren.Entities.Concrete
{
    public class ProductComment:Entity
    {
        public string Title { get; set; }
        public string Comment { get; set; }

        /*
         * Eğer yorum, ana yorumsa commentId = 0  olacaktır.
         * Herhangi bir yoruma alt yorum olarak atılmışsa, ana yorumun id'si gelecektir.
         */
        public int CommentId { get; set; } = 0;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
