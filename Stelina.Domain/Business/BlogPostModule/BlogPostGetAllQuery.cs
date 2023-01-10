using MediatR;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.AppCode.Infrastructure;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.BlogPostModule
{
    public class BlogPostGetAllQuery : PaginateModel, IRequest<PagedViewModel<BlogPost>>
    {

        public class BlogPostGetAllQueryHandler : IRequestHandler<BlogPostGetAllQuery, PagedViewModel<BlogPost>>
        {
            private readonly StelinaDbContext db;

            public BlogPostGetAllQueryHandler(StelinaDbContext db)
            {
                this.db = db;
            }
            public async Task<PagedViewModel<BlogPost>> Handle(BlogPostGetAllQuery request, CancellationToken cancellationToken)
            {
                int skipSize = (request.PageIndex - 1) * request.PageSize;

                var query = db.BlogPosts
                .Where(bp => bp.DeletedDate == null && bp.PublishedDate != null)
                .Include(bp=>bp.Category)
                .OrderByDescending(bp => bp.PublishedDate)
                .AsQueryable();

                var pagedModel = new PagedViewModel<BlogPost>(query, request);

                return pagedModel;
            }
        }
    }
}
