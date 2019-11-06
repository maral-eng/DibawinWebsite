using DibawinWebsite.Areas.Identity.Data;
using DibawinWebsite.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DibawinWebsite.Models
{
    public partial class Setting : IEntity<int>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? BaseCurrencyId { get; set; }
        public bool IsStatusActive { get; set; }
        public bool IsMarketPlace { get; set; }
        public bool Status { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public string AdminEmail { get; set; }
        public string AdminEmailPassword { get; set; }
        public string EmailPort { get; set; }
        public string EmailProtocol { get; set; }
        public string EmailServiceProvider { get; set; }
        public string SMSUsername { get; set; }
        public string SMSPassword { get; set; }
        public string SMSApiAddress { get; set; }
        public string SMSApiNumber { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}
