using DibawinWebsite.Areas.Identity.Data;
using DibawinWebsite.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DibawinWebsite.Models
{
    public class Projects : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string LatinTitle { get; set; }
        public bool Status { get; set; }
        public DateTime RegDateTime { get; set; }
        public string DefinedByUserId { get; set; }
        public string ModifiedByUsers { get; set; } //comination of UserId and ModifiedDateTime
        //======================================================================================

        public string ProjectManagerFullName { get; set; }
        public string ProjectManagerId { get; set; }
        public string Collaborators { get; set; } //seperate names with ',' (comma)
        public bool Deleted { get; set; }

        public int? CategoryId { get; set; }
        public int? ClientId { get; set; }

        public string Description { get; set; }
        public DateTime? Starts { get; set; }
        public DateTime? Ends { get; set; }

        [ForeignKey("ProjectManagerId")]
        public virtual ApplicationUser ProjectManager { get; set; }

        [ForeignKey("DefinedByUserId")]
        public virtual ApplicationUser DefinedByUser { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("ClientId")]
        public virtual Clients Client { get; set; }

        public virtual ICollection<ProjectsImages> ProjectsImages { get; set; }
        public virtual ICollection<ProjectsFeatures> ProjectsFeatures { get; set; }

    }
}
