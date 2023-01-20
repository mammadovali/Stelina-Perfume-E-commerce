using MediatR;
using Microsoft.EntityFrameworkCore;
using Stelina.Domain.Models.DataContexts;
using Stelina.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stelina.Domain.Business.FaqModule
{

    public class FaqEditCommand : IRequest<Faq>
    {
        public int Id { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }


        public class FaqEditCommandHandler : IRequestHandler<FaqEditCommand, Faq>
        {
            private readonly StelinaDbContext db;

            public FaqEditCommandHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<Faq> Handle(FaqEditCommand request, CancellationToken cancellationToken)
            {
                var entity = await db.Faqs
                    .FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null, cancellationToken);

                if (entity == null)
                {
                    return null;
                }

                entity.Question = request.Question;

                entity.Answer = request.Answer;


                await db.SaveChangesAsync(cancellationToken);

                return entity;
            }


        }
    }
}
