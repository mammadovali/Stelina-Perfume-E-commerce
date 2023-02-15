using MediatR;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.TagModule
{

    public class TagRemoveCommand : IRequest<Tag>
    {
        public int Id { get; set; }

        public class TagRemoveCommandHandler : IRequestHandler<TagRemoveCommand, Tag>
        {
            private readonly StelinaDbContext db;

            public TagRemoveCommandHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<Tag> Handle(TagRemoveCommand request, CancellationToken cancellationToken)
            {
                var data = db.Tags.FirstOrDefault(m => m.Id == request.Id && m.DeletedDate == null);

                if (data == null)
                {
                    return null;
                }

                data.DeletedDate = DateTime.UtcNow.AddHours(4);

                await db.SaveChangesAsync(cancellationToken);
                return data;
            }
        }
    }
}
