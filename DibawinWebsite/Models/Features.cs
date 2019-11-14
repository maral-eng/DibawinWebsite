using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DibawinWebsite.Models
{
    public class Features
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string LatinTitle { get; set; }
        public bool Status { get; set; }
        public DateTime RegDateTime { get; set; }
        public string DefinedByUserId { get; set; }
        public string Comment { get; set; }
        public byte[] Image { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<ProjectsFeatures> ProjectsFeatures { get; set; }
    }
}
