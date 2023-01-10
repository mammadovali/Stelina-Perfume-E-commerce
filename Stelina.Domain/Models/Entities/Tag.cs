using Stelina.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.Entities
{
    public class Tag : BaseEntity
    {
        [Required]
        public string Text { get; set; }

        public virtual ICollection<BlogPostTagItem> TagCloud { get; set; }

    }
}
