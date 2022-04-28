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
    public class CheckOutManager : ICheckOutManager
    {
        private readonly FruitkhaDbContext _context;

        public CheckOutManager(FruitkhaDbContext context)
        {
            _context = context;
        }

       

        public List<Check> GetAll()
        {
            return _context.Checks.ToList();
        }



        public void Post(Check checks)
        {
            _context.Checks.Add(checks);
            _context.SaveChanges();
        }

    }
}
