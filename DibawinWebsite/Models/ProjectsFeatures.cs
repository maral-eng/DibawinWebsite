using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DibawinWebsite.Models
{
    public class ProjectsFeatures
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int FeatureId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Projects Projects { get; set; }

        [ForeignKey("FeatureId")]
        public virtual Features Features { get; set; }
    }
}
