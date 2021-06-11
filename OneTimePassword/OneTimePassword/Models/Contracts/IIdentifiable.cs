using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTimePassword.Models.Contracts
{
    interface IIdentifiable
    {
        int Id { get; set; }
    }
}
