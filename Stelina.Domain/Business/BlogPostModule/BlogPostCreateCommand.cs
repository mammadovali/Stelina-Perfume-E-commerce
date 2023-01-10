using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Stelina.Domain.AppCode.Extensions;
using Stelina.Domain.AppCode.Infrastructure;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.BlogPostModule
{
    public class BlogPostCreateCommand : IRequest<JsonResponse>
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public string ImagePath { get; set; }

        public int CategoryId { get; set; }

        public IFormFile Image { get; set; }

        public int[] TagIds { get; set; }

        public class BlogPostCreateCommandHandler : IRequestHandler<BlogPostCreateCommand, JsonResponse>
        {
            private readonly StelinaDbContext db;
            private readonly IHostEnvironment env;

            public BlogPostCreateCommandHandler(StelinaDbContext db, IHostEnvironment env)
            {
                this.db = db;
                this.env = env;
            }

            public async Task<JsonResponse> Handle(BlogPostCreateCommand request, CancellationToken cancellationToken)
            {
                var entity = new BlogPost();
                entity.TagCloud = new List<BlogPostTagItem>();

                entity.Body = request.Body;
                entity.Title = request.Title;
                entity.CategoryId = request.CategoryId;

                if (request.Image == null)
                    goto end;

                string extexsion = Path.GetExtension(request.Image.FileName); //.jpg, png 

                request.ImagePath = $"blogpost-{Guid.NewGuid().ToString().ToLower()}{extexsion}";

                string fullPath = env.GetImagePhysicalPath(request.ImagePath);


                using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    request.Image.CopyTo(fs);
                }

                entity.ImagePath = request.ImagePath;

            end:

                entity.Slug = request.Title.ToSlug();

                if (request.TagIds != null)
                {
                    foreach (var exceptedId in request.TagIds)
                    {
                        var tagItem = new BlogPostTagItem();

                        tagItem.TagId = exceptedId;
                        entity.TagCloud.Add(tagItem);
                    }

                }


                await db.BlogPosts.AddAsync(entity, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);

                return new JsonResponse
                {
                    Error = false,
                    Message = "Success"
                };
            }


        }
    }

}
