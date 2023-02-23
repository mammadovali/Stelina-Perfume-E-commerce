using Stelina.Domain.Models.Entities.Membership;
using System;

namespace Stelina.Domain.Models.Entities
{
    public class ProductRate
    {
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public byte Rate { get; set; }

        public int? CreatedByUserId { get; set; }

        public StelinaUser CreatedByUser { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(4);

        public int? DeletedUserId { get; set; }

        public StelinaUser DeletedByUser { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}
