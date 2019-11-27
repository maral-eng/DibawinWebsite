using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DibawinWebsite.ClassLibraries.Validation
{
    public class RequiredIfAttribute : ValidationAttribute
    {
        string TargetName;
        public RequiredIfAttribute(string TargetName)
        {
            this.TargetName = TargetName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var TargetProperty = validationContext.ObjectType.GetProperty(TargetName);
            var TargetValue = TargetProperty.GetValue(validationContext.ObjectInstance);

            if (value != null && TargetValue == null)
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"The other field must be filled if this field is filled";
        }
    }
}
