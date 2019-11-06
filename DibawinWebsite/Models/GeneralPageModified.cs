using DibawinWebsite.Areas.Identity.Data;
using DibawinWebsite.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DibawinWebsite.Models
{
    public partial class GeneralPageModified : IEntity<int>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? GeneralPageId { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public bool Status { get; set; }
        public string LastGeneralPageBackupJson { get; set; }

        [ForeignKey("GeneralPageId")]
        public virtual GeneralPage GeneralPage { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}
