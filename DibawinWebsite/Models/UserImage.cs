using DibawinWebsite.Areas.Identity.Data;
using DibawinWebsite.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DibawinWebsite.Models
{
    public partial class UserImage : IEntity<int>
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public byte[] Image { get; set; }
        public DateTime? RegDateTime { get; set; }
        public bool Status { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
        public byte[] ImageThumbnail { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}
