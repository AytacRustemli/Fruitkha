using Entities;

namespace Fruitkhhaa.ViewModel
{
    public class ProductVM
    {
        public Product ProductSingle { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public Organic Organic { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
