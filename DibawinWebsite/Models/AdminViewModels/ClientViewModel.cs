using DibawinWebsite.ClassLibraries.Validation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DibawinWebsite.Models.AdminViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "تکمیل این فیلد الزامی میباشد")]
        [DisplayName("عنوان")]
        public string Title { get; set; }
        public string LatinTitle { get; set; }
        public bool Status { get; set; }
        public DateTime RegDateTime { get; set; }
        public string DefinedByUserId { get; set; }
        public string ModifiedByUsers { get; set; } //comination of 'UserId' and 'ModifiedDateTime'
        //=========================================================================================
        public string UserId { get; set; }

        [Required(ErrorMessage = "تکمیل این فیلد الزامی میباشد")]
        public string ClientCode { get; set; }
        public string ManagerFullName { get; set; }
        public bool IsRealPersonality { get; set; }
        public IFormFile Logo { get; set; }
        public IFormFile LogoTiny { get; set; }
        public bool Deleted { get; set; }

        //===== Require User Info =================================================================
        public string PhoneNumber { get; set; }

        [RequiredBinding("Mobile", ErrorMessage ="تکمیل فیلد شماره موبایل و یا ایمیل کارفرما اجباری میباشد")]
        public string Email { get; set; }
        public string Mobile { get; set; }

        //===== Address Info ======================================================================
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string PostalCode { get; set; }
        public string Coordinates { get; set; }//مختصات آدرس جهت استفاده در نقشه
        public string SocialMediaLinks { get; set; }
        public string Comment { get; set; }
    }
}
