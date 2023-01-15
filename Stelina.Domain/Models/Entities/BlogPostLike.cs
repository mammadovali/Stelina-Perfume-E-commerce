using Stelina.Domain.AppCode.Infrastructure;
using Stelina.Domain.Models.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.Entities
{
    public class BlogPostLike : BaseEntity
    {
        public int BlogPostId { get; set; }

        public virtual BlogPost BlogPost { get; set; }

        public StelinaUser CreatedByUser { get; set; }

        public int CreatedByUserId { get; set; }
    }
}
