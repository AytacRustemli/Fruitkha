using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Abstract
{
    public interface IPhotoManager
    {
        List<Photo> GetAll();
        Photo GetById(int? id);
        void Create(Photo photo);
        void Edit(Photo photo);
        void Delete(Photo photo);
    }
}
