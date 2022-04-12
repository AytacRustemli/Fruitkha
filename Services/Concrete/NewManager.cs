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
    public class NewManager : INewManager
    {
        private readonly FruitkhaDbContext _context;

        public NewManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(New news)
        {
            _context.News.Add(news);
            _context.SaveChanges();
        }

        public void Delete(New news)
        {
            _context.News.Remove(news);
            _context.SaveChanges();
        }

        public void Edit(New news)
        {
            _context.News.Update(news);
            _context.SaveChanges();
        }

        public List<New> GetAll()
        {
            var newss = _context.News.ToList();
            return newss;
        }

        public New GetById(int id)
        {
            var news = _context.News.FirstOrDefault(x => x.Id == id);
            return news;
        }
    }
}
