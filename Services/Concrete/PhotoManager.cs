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
    public class PhotoManager : IPhotoManager
    {
        private readonly FruitkhaDbContext _context;
        public PhotoManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(Photo photo)
        {
            _context.Photos.Add(photo);
            _context.SaveChanges();
        }

        public void Delete(Photo photo)
        {
            _context.Photos.Remove(photo);
            _context.SaveChanges();
        }

        public void Edit(Photo photo)
        {
            _context.Photos.Update(photo);
            _context.SaveChanges();
        }

        public List<Photo> GetAll()
        {
            return _context.Photos.ToList();
        }

        public Photo GetById(int? id)
        {
            return _context.Photos.FirstOrDefault(x => x.Id == id);
        }
    }
}
