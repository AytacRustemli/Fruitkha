using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Abstract
{
    public interface IContactManager
    {
        List<Contact> GetAll();
        void Post(Contact contact);
    }
}
