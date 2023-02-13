using Stelina.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stelina.Domain.Models.Entities
{
    public class ContactPost : BaseEntity
    {
        [Required(ErrorMessage = "{0} Cannot be left empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} Cannot be left empty")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Cannot be left empty")]

        public string Subject { get; set; }
        [Required(ErrorMessage = "Cannot be left empty")]

        public string Content { get; set; }

        public string Answer { get; set; }

        public string EmailSubject { get; set; }

        public DateTime? AnswerDate { get; set; }
    }
}
