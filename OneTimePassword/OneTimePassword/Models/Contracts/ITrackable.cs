using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTimePassword.Models.Contracts
{
    interface ITrackable
    {
        DateTime DateCreation { get; set; }
    }
}
