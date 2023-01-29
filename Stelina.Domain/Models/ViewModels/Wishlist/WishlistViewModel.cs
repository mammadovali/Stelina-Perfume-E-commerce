using Stelina.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.ViewModels.Wishlist
{
    public class WishlistViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public Basket Basket { get; set; }
    }
}
