using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DibawinWebsite.Models.ViewModels
{
    public class SignupViewModel
    {
        [Required(ErrorMessage = "لطفا نام کاربری را وارد نمایید")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "ایمیل را صحیح وارد نمایید")]
        public string Username { get; set; }
        [Required(ErrorMessage = "لطفا کلمه عبور را وارد نمایید")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "با پسورد وارد شده همخوانی ندارد")]
        public string ConfirmPassword { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public IFormFile img { get; set; }
        public string Phonenumber { get; set; }
        public string Nationalcode { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public bool? Gender { get; set; }
        public bool Specialuser { get; set; }
        public bool Status { get; set; }
        public string DefinedByUserId { get; set; }
        public string RoleName { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
