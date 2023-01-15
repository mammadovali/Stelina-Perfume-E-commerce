using Stelina.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.Entities
{
    public class Subscribe : BaseEntity
    {
        [Required(ErrorMessage = "{0} boş buraxıla bilməz")]
        public string Email { get; set; }

        public DateTime? ApprovedDate { get; set; }

        public bool IsApproved { get; set; } = false;

    }
}
