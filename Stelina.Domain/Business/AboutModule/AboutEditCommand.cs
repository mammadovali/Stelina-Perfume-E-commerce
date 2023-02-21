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

namespace Stelina.Domain.Business.AboutModule
{

    public class AboutEditCommand : IRequest<JsonResponse>
    {
        public int Id { get; set; }

        public string ImagePath { get; set; }

        [Required]
        public string BoldText { get; set; }

        [Required]
        public string NormalText { get; set; }

        [Required]
        public string FreeDeliveryText { get; set; }

        [Required]
        public string MoneyGuaranteeText { get; set; }

        [Required]
        public string OnlineSupportText { get; set; }

        public IFormFile Image { get; set; }


        public class AboutEditCommandHandler : IRequestHandler<AboutEditCommand, JsonResponse>
        {
            private readonly StelinaDbContext db;
            private readonly IHostEnvironment env;

            public AboutEditCommandHandler(StelinaDbContext db, IHostEnvironment env)
            {
                this.db = db;
                this.env = env;
            }

            public async Task<JsonResponse> Handle(AboutEditCommand request, CancellationToken cancellationToken)
            {
                var entity = await db.AboutCompany
                       .FirstOrDefaultAsync(bp => bp.Id == request.Id && bp.DeletedDate == null);

                if (entity == null)
                {
                    return null;
                }

                entity.BoldText = request.BoldText;
                entity.NormalText = request.NormalText;
                entity.FreeDeliveryText = request.FreeDeliveryText;
                entity.MoneyGuaranteeText = request.MoneyGuaranteeText;
                entity.OnlineSupportText = request.OnlineSupportText;

                if (request.Image == null)
                    goto end;


                string extexsion = Path.GetExtension(request.Image.FileName); //.jpg, png 

                request.ImagePath = $"about-{Guid.NewGuid().ToString().ToLower()}{extexsion}";

                string fullPath = env.GetImagePhysicalPath(request.ImagePath);


                using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    request.Image.CopyTo(fs);
                }

                string oldPath = env.GetImagePhysicalPath(entity.ImagePath);



                //env.ArchiveImage(entity.ImagePath);

                entity.ImagePath = request.ImagePath;

            end:
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
