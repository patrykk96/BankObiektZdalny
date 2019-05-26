using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BankLogic : MarshalByRefObject
    {
        List<Client> clientList = new List<Client>();

        public BankLogic()
        {
            clientList.Add(
                new Client()
                {
                    AccountNumber = "1234",
                    PinNumber = "1234",
                    Token = "",
                    AccountBalance = 50.00
                }
            );

            clientList.Add(
                new Client()
                {
                    AccountNumber = "123",
                    PinNumber = "123",
                    Token = "",
                    AccountBalance = 2000.00
                }
            );

            clientList.Add(
                new Client()
                {
                    AccountNumber = "12",
                    PinNumber = "12",
                    Token = "",
                    AccountBalance = 450.55
                }
            );
        }

        public string Authorize(string AccountNumber, string Pin)
        {
            var client = clientList.FirstOrDefault(x => x.AccountNumber == AccountNumber);

            if (client == null || client.PinNumber != Pin || client.Token != "")
                return "";

            string token = Guid.NewGuid().ToString();
            client.Token = token;

            return token;
        }

        public double GetBalance(string token)
        {
            var client = clientList.FirstOrDefault(x => x.Token == token);

            if (client == null)
            {
                return -1;
            }

            return client.AccountBalance;
        }

        public void Deposit(string token, double value)
        {
            var client = clientList.FirstOrDefault(x => x.Token == token);

            if (client != null && value > 0)
            {
                client.AccountBalance += value;
            }
        }

        public bool Withdraw(string token, double value)
        {
            var client = clientList.FirstOrDefault(x => x.Token == token);

            if (client != null && value > 0)
            {
                if (client.AccountBalance > value)
                {
                    client.AccountBalance -= value;
                    return true;
                }
            }

            return false;
        }

        public bool Withdraw(string token, string account, double value)
        {
            var client = clientList.FirstOrDefault(x => x.Token == token);

            if (client != null || client.AccountNumber != account)
            {
                if (client.AccountBalance > value && value > 0)
                {
                    var target = clientList.FirstOrDefault(x => x.AccountNumber == account);
                    if (target != null)
                    {
                        client.AccountBalance -= value;
                        target.AccountBalance += value;
                        return true;
                    }
                }
            }

            return false;
        }

        public void Bye(string token)
        {
            var client = clientList.FirstOrDefault(x => x.Token == token);

            if (client != null)
            {
                client.Token = "";
            }
        }
    }
    
}
