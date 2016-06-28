using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Lexicon_LMS.Models
{

    public class Course
    {
        public int CourseId { get; set; }
        [DisplayName("CourseName")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }


    }
}