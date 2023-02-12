using Stelina.Domain.AppCode.Infrastructure;
using Stelina.Domain.Models.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.Entities
{
    public class Order : BaseEntity
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int PhoneNumber { get; set; }

        public decimal TotalAmount { get; set; }

        public string Address { get; set; }

        public StelinaUser Customer { get; set; }

        public int CustomerId { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
