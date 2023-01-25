using Stelina.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.ViewModels.ProductViewModel
{
    public class ProductViewModel
    {
        public ICollection<Brand> Brands { get; set; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
