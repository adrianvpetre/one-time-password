using OneTimePassword.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTimePassword.Models.Entities
{
    public class Password : ITrackable
    {
        public DateTime DateCreation { get; set; }
        public string AccessCode { get; set; }
    }
}
