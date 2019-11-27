using DibawinWebsite.Areas.Identity.Data;
using DibawinWebsite.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DibawinWebsite.Models
{
    public class Skills : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string LatinTitle { get; set; }
        public bool Status { get; set; }
        public DateTime RegDateTime { get; set; }
        public string DefinedByUserId { get; set; }
        public string ModifiedByUsers { get; set; } //comination of 'UserId' and 'ModifiedDateTime'
        //=========================================================================================

        [ForeignKey("DefinedByUserId")]
        public virtual ApplicationUser DefinedByUser { get; set; }
    }
}
