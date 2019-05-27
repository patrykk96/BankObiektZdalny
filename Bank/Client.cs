using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Client : Entity
    {
        public string AccountNumber { get; set; }
        public byte[] PinNumberSalt { get; set; }
        public byte[] PinNumberHash { get; set; }
        public string Token { get; set; }
        public double AccountBalance { get; set; }
        public int Currency { get; set; }
    }
}
