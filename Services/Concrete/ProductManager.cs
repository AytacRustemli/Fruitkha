using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entities;
using Services.Abstract;

namespace Services.Concrete
{
    public class ProductManager : IProductManager
    {
        private readonly FruitkhaDbContext _context;

        public ProductManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void Edit(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            var product = _context.Products.ToList();
            return product;
        }

        public Product GetById(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }
    }
}
