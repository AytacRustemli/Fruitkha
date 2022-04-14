using DataAccess;
using Entities;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class DealManager : IDealManager
    {
        private readonly FruitkhaDbContext _context;

        public DealManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(Deal deal)
        {
            _context.Deals.Add(deal);
            _context.SaveChanges();
        }

        public void Delete(Deal deal)
        {
            _context.Deals.Remove(deal);
            _context.SaveChanges();
        }

        public void Edit(Deal deal)
        {
            _context.Deals.Update(deal);
            _context.SaveChanges();
        }

        public List<Deal> GetAll()
        {
            return _context.Deals.ToList();
        }

        public Deal GetById(int? id)
        {
            return _context.Deals.FirstOrDefault(x => x.Id == id);
        }
    }
}
