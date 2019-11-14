using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DibawinWebsite.Models.AdminViewModels
{
    public class ProjectClientViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="تکمیل این فیلد الزامی میباشد")]
        [DisplayName("عنوان")]
        public string Title { get; set; }

        [DisplayName("عنوان لاتین")]
        public string LatinTitle { get; set; }

        [DisplayName("وضعیت")]
        public bool Status { get; set; }

        [DisplayName("تاریخ ثبت")]
        public DateTime RegDateTime { get; set; }

        public string DefinedByUserId { get; set; }

        [DisplayName("ویرایش شده توسط ")]
        public string ModifiedByUsers { get; set; }

        [DisplayName("مدیر پروژه")]
        public string ProjectManagerFullName { get; set; }

        public string ProjectManagerId { get; set; }

        [DisplayName("همکاران پروژه")]
        public string Collaborators { get; set; } //seperate names with ',' (comma)

        [DisplayName("حذف شده")]
        public bool Deleted { get; set; }

        [DisplayName("آی دی دسته بندی")]
        public int? CategoryId { get; set; }

        [DisplayName("آی دی کارفرما")]
        [Required(ErrorMessage = "تکمیل این فیلد الزامی میباشد")]
        public int? ClientId { get; set; }

        [DisplayName("توضیحات")]
        public string Description { get; set; }

        [DisplayName("تاریخ شروع")]
        public DateTime? Starts { get; set; }

        [DisplayName("تاریخ پایان")]
        public DateTime? Ends { get; set; }

        //------------------------------------------------------------------------------
        [DisplayName("ثبت شده توسط")]
        public string DefinedByUser { get; set; }

        [DisplayName("دسته بندی")]
        public string Category { get; set; }

        [DisplayName("کارفرما")]
        public string Client { get; set; }

        [DisplayName("تصاویر")]
        public List<IFormFile> img { get; set; }

        [Required]
        [DisplayName("تصویر‌اصلی")]
        public IFormFile MainImage { get; set; } //تصویر اصلی 

    }
}
