using Stelina.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.Entities
{
    public class About : BaseEntity
    {
        public string ImagePath { get; set; }

        public string BoldText { get; set; }

        public string NormalText { get; set; }

        public string FreeDeliveryText { get; set; }

        public string MoneyGuaranteeText { get; set; }

        public string OnlineSupportText { get; set; }
    }
}
