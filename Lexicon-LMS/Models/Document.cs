 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lexicon_LMS.Models
{

    public class Document
    {
        public int DocumentId { get; set; }
        [Display(Name = "File Name")]
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

        public bool IsHandIn { get; set; }
        public string UserId { get; set; }
        public int? ActivityId { get; set; }
        public int? CourseId { get; set; }
        public int? ModuleId { get; set; }
       
        public virtual Activity Activity { get; set; }
        public virtual Course Course { get; set; }
        public virtual Module Module { get; set; }

        public virtual ApplicationUser User { get; set; }

    }
}