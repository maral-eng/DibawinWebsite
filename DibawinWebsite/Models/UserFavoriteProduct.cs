using DibawinWebsite.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DibawinWebsite.Models
{
    public partial class UserFavoriteProduct
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? RegDateTime { get; set; }
        public bool Status { get; set; }

        [ForeignKey("ProductId")]
        public virtual ProductAbstract Product { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}
