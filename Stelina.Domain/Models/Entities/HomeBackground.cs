using Stelina.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.Entities
{
    public class HomeBackground : BaseEntity
    {
        public string Text { get; set; }

        public string ImagePath { get; set; }
    }
}
