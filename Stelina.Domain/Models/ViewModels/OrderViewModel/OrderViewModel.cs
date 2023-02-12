using Stelina.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.ViewModels.OrderViewModel
{
    public class OrderViewModel
    {
        public IEnumerable<Basket> BasketProducts { get; set; }

        public Order OrderDetails { get; set; }
    }
}
