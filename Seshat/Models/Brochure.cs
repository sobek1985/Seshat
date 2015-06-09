using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MikeRobbins.Seshat.Attributes;

namespace MikeRobbins.Seshat.Models
{
    public class Brochure : Sitecore.Services.Core.Model.EntityIdentity
    {
        public string itemId
        {
            get { return Id; }
        }

        public string Icon { get; set; }

        [Required]
        public string Title { get; set; }

        public string Introduction { get; set; }

        public Guid CaseStudy { get; set; }

        public Guid Image { get; set; }

        [NotPastDate(ErrorMessage = "Date must be in the past")]
        public DateTime Date { get; set; }
    }
}