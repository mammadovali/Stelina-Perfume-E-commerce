﻿using Stelina.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.Entities
{
    public class Product : BaseEntity, IPageable
    {
        public string Name { get; set; }

        public string StockKeepingUnit { get; set; }

        public double Rate { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<ProductImage> Images { get; set; }
    }
}
