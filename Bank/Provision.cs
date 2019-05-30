using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Provision : Entity
    {
        public int Source { get; set; }
        public int Target { get; set; }
        public double Amount { get; set; }
    }
}
