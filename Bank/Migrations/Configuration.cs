namespace Bank.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Bank.BankContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Bank.BankContext context)
        {
            if (context.Set<Client>().Any() == false)
            {
                var clientList = new List<Client>();

                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("1234", out passwordHash, out passwordSalt);

                clientList.Add(
                new Client()
                {
                    AccountNumber = "1234",
                    PinNumberSalt = passwordSalt,
                    PinNumberHash = passwordHash,
                    Token = "",
                    AccountBalance = 50.00
                }
             );

                CreatePasswordHash("123", out passwordHash, out passwordSalt);
                clientList.Add(
                    new Client()
                    {
                        AccountNumber = "123",
                        PinNumberSalt = passwordSalt,
                        PinNumberHash = passwordHash,
                        Token = "",
                        AccountBalance = 2000.00
                    }
                );

                CreatePasswordHash("12", out passwordHash, out passwordSalt);
                clientList.Add(
                    new Client()
                    {
                        AccountNumber = "12",
                        PinNumberSalt = passwordSalt,
                        PinNumberHash = passwordHash,
                        Token = "",
                        AccountBalance = 450.55
                    }
                );

                context.Set<Client>().AddRange(clientList);
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
