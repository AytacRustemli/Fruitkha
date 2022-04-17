using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Migrations;
using Services.Abstract;
using Entities;

namespace Services.Concrete
{
    public class ContactManager : IContactManager
    {
        private readonly FruitkhaDbContext _context;

        public ContactManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public List<Entities.Contact> GetAll()
        {
            return _context.Contacts.ToList();
        }

        public void Post(Entities.Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }
    }
}
