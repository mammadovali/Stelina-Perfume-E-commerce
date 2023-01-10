using Stelina.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
