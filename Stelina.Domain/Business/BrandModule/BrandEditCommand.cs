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

namespace Stelina.Domain.Business.BrandModule
{

    public class BrandEditCommand : IRequest<Brand>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public class BrandEditCommandHandler : IRequestHandler<BrandEditCommand, Brand>
        {
            private readonly StelinaDbContext db;

            public BrandEditCommandHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<Brand> Handle(BrandEditCommand request, CancellationToken cancellationToken)
            {
                var entity = await db.Brands
                       .FirstOrDefaultAsync(bp => bp.Id == request.Id && bp.DeletedDate == null);
                if (entity == null)
                {
                    return null;
                }

                entity.Name = request.Name;

                await db.SaveChangesAsync(cancellationToken);

                return entity;
            }


        }
    }
}
