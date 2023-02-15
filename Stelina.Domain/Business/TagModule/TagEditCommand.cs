using MediatR;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.TagModule
{

    public class TagEditCommand : IRequest<Tag>
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }


        public class TagEditCommandHandler : IRequestHandler<TagEditCommand, Tag>
        {
            private readonly StelinaDbContext db;

            public TagEditCommandHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<Tag> Handle(TagEditCommand request, CancellationToken cancellationToken)
            {
                var entity = await db.Tags
                       .FirstOrDefaultAsync(bp => bp.Id == request.Id && bp.DeletedDate == null);
                if (entity == null)
                {
                    return null;
                }

                entity.Text = request.Text;

                await db.SaveChangesAsync(cancellationToken);

                return entity;
            }


        }
    }
}
