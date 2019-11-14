using DibawinWebsite.Areas.Identity.Data;
using DibawinWebsite.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DibawinWebsite.Models
{
    public class ClientAddress : IEntity<int>
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public bool Deleted { get; set; }
        public DateTime RegDateTime { get; set; }
        public string DefinedByUserId { get; set; }
        public string ModifiedByUsers { get; set; } //comination of UserId and ModifiedDateTime

        public int ClientId { get; set; }

        public int? CityId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CountryId { get; set; }

        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string PostalCode { get; set; }
        public string Coordinates { get; set; }//مختصات آدرس جهت استفاده در نقشه
        public string SocialMediaLinks { get; set; }
        public string Comment { get; set; }

        [ForeignKey("DefinedByUserId")]
        public ApplicationUser DefinedByUser { get; set; }

        [ForeignKey("ClientId")]
        public Clients Client { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [ForeignKey("ProvinceId")]
        public virtual Province Province { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}
