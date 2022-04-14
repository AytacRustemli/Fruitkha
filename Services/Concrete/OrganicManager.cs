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
    public class OrganicManager : IOrganicManager
    {
        private readonly FruitkhaDbContext _context;

        public OrganicManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(Organic organic)
        {
            _context.Organics.Add(organic);
            _context.SaveChanges();
        }

        public void Delete(Organic organic)
        {
            _context.Organics.Remove(organic);
            _context.SaveChanges();
        }

        public void Edit(Organic organic)
        {
            _context.Organics.Update(organic);
            _context.SaveChanges();
        }

        public List<Organic> GetAll()
        {
            var organic = _context.Organics.ToList();
            return organic;
        }

        public Organic GetById(int id)
        {
            var organic = _context.Organics.FirstOrDefault(x => x.Id == id);
            return organic;
        }
    }
}
