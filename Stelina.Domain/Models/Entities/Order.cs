using Stelina.Domain.AppCode.Infrastructure;
using Stelina.Domain.Models.Entities.Membership;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stelina.Domain.Models.Entities
{
    public class Order : BaseEntity
    {
        [Required(ErrorMessage = "{0} cannot be left empty")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "{0} cannot be left empty")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "{0} cannot be left empty")]
        public string PhoneNumber { get; set; }

        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "{0} cannot be left empty")]
        public string Address { get; set; }

        public virtual StelinaUser User { get; set; }

        public int UserId { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
