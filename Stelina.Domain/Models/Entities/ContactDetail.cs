using Stelina.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.Entities
{
    public class ContactDetail : BaseEntity
    {
        [Required]
        public string PhoneNumber { get; set; }

        public string Location { get; set; }

        public string SupportEmail { get; set; }
    }
}
