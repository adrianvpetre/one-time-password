using OneTimePassword.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTimePassword.Services.Contracts
{
    public interface IPasswordGenerator
    {
        bool CheckPassword(Password password);
        Password GeneratePassword();
    }
}
