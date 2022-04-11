using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Owner : Base
    {
        public string PhotoURL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
    }
}
