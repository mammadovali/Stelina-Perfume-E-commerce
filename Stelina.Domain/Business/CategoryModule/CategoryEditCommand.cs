using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Stelina.Domain.AppCode.Extensions;
using Stelina.Domain.AppCode.Infrastructure;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.CategoryModule
{

    public class CategoryEditCommand : IRequest<Category>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? ParentId { get; set; }

        public class CategoryEditCommandHandler : IRequestHandler<CategoryEditCommand, Category>
        {
            private readonly StelinaDbContext db;

            public CategoryEditCommandHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<Category> Handle(CategoryEditCommand request, CancellationToken cancellationToken)
            {
                var entity = await db.Categories
                       .Include(c => c.Parent)
                       .FirstOrDefaultAsync(bp => bp.Id == request.Id && bp.DeletedDate == null);
                if (entity == null)
                {
                    return null;
                }

                entity.Name = request.Name;
                entity.ParentId = request.ParentId;


                await db.SaveChangesAsync(cancellationToken);

                return entity;
            }


        }
    }
}
