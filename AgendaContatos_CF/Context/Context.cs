using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Hierarchy;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContatos_CF
{
    internal class Context : DbContext
    {
        public Context() : base("BaseContatos"){} 
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Telephone> Telephone { get; set; }
    }
}
