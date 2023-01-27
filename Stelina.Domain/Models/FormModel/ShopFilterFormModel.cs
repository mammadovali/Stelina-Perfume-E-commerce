using System.Collections.Generic;

namespace Stelina.Domain.Models.FormModel
{
    public class ShopFilterFormModel
    {
        public ICollection<int> Brands { get; set; }

        public ICollection<int> Categories { get; set; }

        public int[] Prices { get; set; }

    }
}
