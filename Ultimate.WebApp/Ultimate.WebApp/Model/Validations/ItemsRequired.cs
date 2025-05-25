using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;
using Ultimate.WebApp.Service;
using Ultimate.WebApp.Shared.ResourceFiles;

namespace Ultimate.WebApp.Model.Validations
{
    public class ItemsRequired:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           List<MenuItemModel>items=value as List<MenuItemModel>;
            if(items.Count<=0)
            {
                var localization = Global.Services.GetRequiredService<IStringLocalizer<Resource>>();

                return new ValidationResult(localization["msg_ItemsRequired"]);
            }
            return ValidationResult.Success;
        }
    }
}
