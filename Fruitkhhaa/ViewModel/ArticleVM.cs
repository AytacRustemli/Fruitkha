using Entities;

namespace Fruitkhhaa.ViewModel
{
    public class ArticleVM
    {
        public New NewSingle { get; set; }
        public List<New> News { get; set; }
        public User User { get; set; }
        public List<Comment> Comments { get; set; }
        public Comment Comment { get; set; }
        public Organic Organic { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
