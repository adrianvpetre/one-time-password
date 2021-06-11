using OneTimePassword.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTimePassword.Models.Entities
{
    public class User : IIdentifiable
    {
        public int Id { get; set; }
        public Password Password { get; set; }
    }
}
