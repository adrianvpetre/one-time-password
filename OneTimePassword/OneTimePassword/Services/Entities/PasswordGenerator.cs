using OneTimePassword.Models.Entities;
using OneTimePassword.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTimePassword.Services.Entities
{
    public class PasswordGenerator: IPasswordGenerator
    {
        private static Random random = new Random();
        private static int passwordLength = 6;

        public PasswordGenerator()
        {

        }

        public bool CheckPassword(Password password)
        {
            if (password.DateCreation < DateTime.UtcNow.AddSeconds(-30))
                return false;
            return true;
        }

        public Password GeneratePassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            string accessCode = new string(Enumerable.Repeat(chars, passwordLength)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return new Password()
            {
                AccessCode = accessCode,
                DateCreation = DateTime.UtcNow
            };
        }
    }
}
