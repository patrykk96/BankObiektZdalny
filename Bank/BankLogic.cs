using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bank
{
    public class BankLogic : MarshalByRefObject
    {
        private readonly Repository _repo = new Repository();

        public BankLogic()
        {
            _repo = new Repository();
        }


        public string Authorize(string AccountNumber, string Pin)
        {
            var client = _repo.GetClient(x => x.AccountNumber == AccountNumber);

            if (client == null || (!VerifyPasswordHash(Pin, client.PinNumberHash, client.PinNumberSalt)))
                return "";

            string token = Guid.NewGuid().ToString();
            client.Token = token;
           // var test = JsonConvert.DeserializeObject<ListCurrency>(File.ReadAllText(@"currencies.json"));
            _repo.UpdateClient();

            return token;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
        }

        public double GetBalance(string token)
        {
            var client = _repo.GetClient(x => x.Token == token);

            if (client == null)
            {
                return -1;
            }

            return client.AccountBalance;
        }

        public void Deposit(string token, double value)
        {
            var client = _repo.GetClient(x => x.Token == token);

            if (client != null && value > 0)
            {
                client.AccountBalance += value;
            }
            _repo.UpdateClient();
        }

        public bool Withdraw(string token, double value)
        {
            var client = _repo.GetClient(x => x.Token == token);

            if (client != null && value > 0)
            {
                if (client.AccountBalance > value)
                {
                    client.AccountBalance -= value;
                    _repo.UpdateClient();
                    return true;
                }
            }

            return false;
        }

        public bool Withdraw(string token, string account, double value)
        {
            var client = _repo.GetClient(x => x.Token == token);

            if (client != null || client.AccountNumber != account)
            {
                if (client.AccountBalance > value && value > 0)
                {
                    var target = _repo.GetClient(x => x.AccountNumber == account);
                    if (target != null)
                    {
                        client.AccountBalance -= value;
                        target.AccountBalance += value;
                        _repo.UpdateClient();
                        return true;
                    }
                }
            }

            return false;
        }

        public string GetCurrency(string token)
        {
            var client = _repo.GetClient(x => x.Token == token);
            string result = "";
            if (client != null)
            {
                int currency = client.Currency;
                switch(currency)
                {
                    case (int)CurrencyEnum.zloty:
                            result = "złotych";
                            break;
                    case (int)CurrencyEnum.dolar:
                        result = "dolarów";
                        break;
                    case (int)CurrencyEnum.euro:
                        result = "euro";
                        break;
                    default:
                        result = "Wystąpił problem z wczytaniem danych";
                        break;
                }
            }
            return result;
        }

        public void Bye(string token)
        {
            var client = _repo.GetClient(x => x.Token == token);

            if (client != null)
            {
                client.Token = "";
            }
            _repo.UpdateClient();
        }
    }
    
}
