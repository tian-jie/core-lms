using CoreLMS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreLMS.Core.Entities
{
    public class Author : IAuditableEntity, IEntity
    {
        public Author()
        {
            this.CourseLessons = new HashSet<AuthorCourseLesson>();
        }

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string Suffix { get; set; }

        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }

        [Phone]
        public string ContactPhoneNumber { get; set; }

        public string Description { get; set; }
        public string WebsiteURL { get; set; }

        public ICollection<AuthorCourseLesson> CourseLessons { get; set; }
    }
}
