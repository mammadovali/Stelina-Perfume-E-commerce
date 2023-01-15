using Stelina.Domain.AppCode.Infrastructure;
using Stelina.Domain.Models.Entities.Membership;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.Entities
{
    public class BlogPost : BaseEntity, IPageable
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        public string ImagePath { get; set; }

        public string Slug { get; set; }

        public DateTime? PublishedDate { get; set; }

        public int? AuthorId { get; set; }

        public ICollection<BlogPostLike> Likes { get; set; }

        public ICollection<BlogPostComment> Comments { get; set; }

        public virtual ICollection<BlogPostTagItem> TagCloud { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }
}
