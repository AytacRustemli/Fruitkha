using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
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

        public List<Product> GetAll(int? pageNo, int recordSize)
        {
            if (pageNo == null)
            {
                pageNo = 1;
            }
            int currentPage = 6 * pageNo.Value - 6;


            var product = _context.Products.Skip(currentPage).Take(recordSize).Include(x => x.Category).ToList();
            return product;
        }

        public int GetAllCount()
        {

            var product = _context.Products.ToList();
            return product.Count;
        }

        public Product GetById(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            
            return product;
        }
    }
}
