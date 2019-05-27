using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Repository
    {
        private readonly BankContext _context;

        public Repository()
        {
            _context = new BankContext();
        }

        public Client GetClient(Func<Client, bool> func)
        {
            var result =  _context.Set<Client>().FirstOrDefault(func);

            return result;
        }

        public void UpdateClient()
        {
            _context.SaveChanges();
        }
    }
}
