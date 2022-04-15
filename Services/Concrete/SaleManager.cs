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
    public class SaleManager : ISaleManager
    {
        private readonly FruitkhaDbContext _context;

        public SaleManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
        }

        public void Delete(Sale sale)
        {
            _context.Sales.Remove(sale);
            _context.SaveChanges();
        }

        public void Edit(Sale sale)
        {
            _context.Sales.Update(sale);
            _context.SaveChanges();
        }

        public List<Sale> GetAll()
        {
            var sale = _context.Sales.ToList();
            return sale;
        }

        public Sale GetById(int id)
        {
            var sale = _context.Sales.FirstOrDefault(x => x.Id == id);
            return sale;
        }
    }
}
