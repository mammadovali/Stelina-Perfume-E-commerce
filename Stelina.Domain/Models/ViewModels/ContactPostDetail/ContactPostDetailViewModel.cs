using System.Collections.Generic;
using Stelina.Domain.Models.Entities;

namespace Stelina.Domain.Models.ViewModels.ContactPostDetail
{
    public class ContactPostDetailViewModel
    {
        public ContactPost ContactPosts { get; set; }

        public ContactDetail ContactDetails { get; set; }
    }
}
