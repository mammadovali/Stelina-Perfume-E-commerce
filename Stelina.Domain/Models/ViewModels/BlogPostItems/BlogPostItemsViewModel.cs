using Stelina.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stelina.Domain.Models.ViewModels.BlogPostItems
{
    public class BlogPostItemsViewModel
    {
        public BlogPost BlogPost { get; set; }

        public ICollection<BlogPostLike> BlogPostLikes { get; set; }
    }
}
