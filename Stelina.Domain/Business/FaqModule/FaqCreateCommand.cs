using MediatR;
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
    public class FaqCreateCommand : IRequest<Faq>
    {

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }


        public class FaqCreateCommandHandler : IRequestHandler<FaqCreateCommand, Faq>
        {
            private readonly StelinaDbContext db;

            public FaqCreateCommandHandler(StelinaDbContext db)
            {
                this.db = db;
            }

            public async Task<Faq> Handle(FaqCreateCommand request, CancellationToken cancellationToken)
            {
                var model = new Faq();

                model.Question = request.Question;

                model.Answer = request.Answer;


                await db.Faqs.AddAsync(model, cancellationToken);

                await db.SaveChangesAsync(cancellationToken);

                return model;
            }


        }
    }

}
