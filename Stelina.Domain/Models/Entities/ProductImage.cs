using Stelina.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.Entities
{
    public class ProductImage : BaseEntity

    {
        public string Name { get; set; }

        public bool IsMain { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
