using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lexicon_LMS.Models
{
    public class Activity
    {

        public int ActivityId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Deadline { get; set; }
        public int ActivityTypeId { get; set; }
        public int ModuleId { get; set; }

        public virtual Module Module { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ActivityType ActivityType { get; set; }

    }
}