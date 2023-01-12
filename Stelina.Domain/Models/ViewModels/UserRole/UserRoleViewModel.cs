using Stelina.Domain.Models.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.ViewModels.UserRole
{
    public class UserRoleViewModel

    {
        public StelinaUser User { get; set; }

        public StelinaRole Role { get; set; }

    }
}
