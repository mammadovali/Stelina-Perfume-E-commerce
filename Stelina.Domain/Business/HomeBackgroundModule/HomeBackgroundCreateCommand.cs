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

namespace Stelina.Domain.Business.HomeBackgroundModule
{
    public class HomeBackgroundCreateCommand : IRequest<HomeBackground>
    {
        
        public string Text { get; set; }

        public string ImagePath { get; set; }

        public IFormFile Image { get; set; }


        public class HomeBackgroundCreateCommandHandler : IRequestHandler<HomeBackgroundCreateCommand, HomeBackground>
        {
            private readonly StelinaDbContext db;
            private readonly IHostEnvironment env;

            public HomeBackgroundCreateCommandHandler(StelinaDbContext db, IHostEnvironment env)
            {
                this.db = db;
                this.env = env;
            }

            public async Task<HomeBackground> Handle(HomeBackgroundCreateCommand request, CancellationToken cancellationToken)
            {
                var entity = new HomeBackground();

                entity.Text = request.Text;

                if (request.Image == null)
                    goto end;

                string extexsion = Path.GetExtension(request.Image.FileName); //.jpg, png 

                request.ImagePath = $"HomeBackground-{Guid.NewGuid().ToString().ToLower()}{extexsion}";

                string fullPath = env.GetImagePhysicalPath(request.ImagePath);


                using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    request.Image.CopyTo(fs);
                }

                entity.ImagePath = request.ImagePath;

            end:

                await db.HomeBackgrounds.AddAsync(entity, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);

                return entity;
            }


        }
    }

}
