using IntlTelInputBlazor;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;
using Ultimate.WebApp.Service;
using Ultimate.WebApp.Shared.ResourceFiles;

namespace Ultimate.WebApp.Model.Validations
{
    public class IntlTelValidation: ValidationAttribute
    {
        public IntlTelValidation()
        {
            var localization = Global.Services.GetRequiredService<IStringLocalizer<Resource>>();
            this.ErrorMessage = localization["msg_InlTelValidation"];
            

        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(base.ErrorMessage, new string[1] { validationContext.MemberName });
            }

            if (!((value as IntlTel) ?? throw new InvalidOperationException("IntlTelephoneAttribute can only validate intlTel")).IsValid)
            {
                return new ValidationResult(base.ErrorMessage, new string[1] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }
}
