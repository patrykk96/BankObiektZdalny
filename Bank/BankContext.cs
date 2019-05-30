using Bank;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BankContext : DbContext
    {
        public BankContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Provision> Provisions { get; set; }
    }
}
