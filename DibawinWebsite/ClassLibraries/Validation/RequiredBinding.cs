using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DibawinWebsite.ClassLibraries.Validation
{
    public class RequiredBindingAttribute : ValidationAttribute
    {
        public string TargetName;

        public RequiredBindingAttribute(string TargetName)
        {
            this.TargetName = TargetName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var targetProperty = validationContext.ObjectType.GetProperty(TargetName);
            var targetValue = targetProperty.GetValue(validationContext.ObjectInstance);

            if (value == null && targetValue == null)
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"At least one of the fields must be filled";
        }
    }
}
