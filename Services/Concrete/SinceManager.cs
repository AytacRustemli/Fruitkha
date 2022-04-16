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
    public class SinceManager : ISinceManager
    {
        private readonly FruitkhaDbContext _context;

        public SinceManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(Since since)
        {
            _context.Sinces.Add(since);
            _context.SaveChanges();
        }

        public void Delete(Since since)
        {
            _context.Sinces.Remove(since);
            _context.SaveChanges();
        }

        public void Edit(Since since)
        {
            _context.Sinces.Update(since);
            _context.SaveChanges();
        }

        public List<Since> GetAll()
        {
            var since = _context.Sinces.ToList();
            return since;
        }

        public Since GetById(int id)
        {
            var since = _context.Sinces.FirstOrDefault(x => x.Id == id);
            return since;
        }
    }
}
