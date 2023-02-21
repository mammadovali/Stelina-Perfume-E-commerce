using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Stelina.Domain.AppCode.Extensions;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.AboutModule
{
    public class AboutCreateCommand : IRequest<About>
    {
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

        public class AboutCreateCommandHandler : IRequestHandler<AboutCreateCommand, About>
        {
            private readonly StelinaDbContext db;
            private readonly IHostEnvironment env;

            public AboutCreateCommandHandler(StelinaDbContext db, IHostEnvironment env)
            {
                this.db = db;
                this.env = env;
            }

            public async Task<About> Handle(AboutCreateCommand request, CancellationToken cancellationToken)
            {
                var entity = new About();

                entity.BoldText = request.BoldText;
                entity.NormalText = request.NormalText;
                entity.FreeDeliveryText = request.FreeDeliveryText;
                entity.MoneyGuaranteeText = request.MoneyGuaranteeText;
                entity.OnlineSupportText = request.OnlineSupportText;


                string extexsion = Path.GetExtension(request.Image.FileName); //.jpg, png 

                request.ImagePath = $"about-{Guid.NewGuid().ToString().ToLower()}{extexsion}";

                string fullPath = env.GetImagePhysicalPath(request.ImagePath);


                using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    request.Image.CopyTo(fs);
                }

                entity.ImagePath = request.ImagePath;

                await db.AboutCompany.AddAsync(entity, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);

                return entity;
            }


        }
    }

}
