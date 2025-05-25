using IntlTelInputBlazor.Validation;
using Microsoft.Extensions.Localization;
using Ultimate.WebApp.Service;

using IntlTelInputBlazor;
using Ultimate.WebApp.Shared.ResourceFiles;
using Ultimate.WebApp.Model.Validations;

namespace Ultimate.WebApp.Model
{
    public class NumberConfirmationsModel
    {

        public string wrongNumberValidation ;
        public NumberConfirmationsModel()
        {
            var localization = Global.Services.GetRequiredService<IStringLocalizer<Resource>>();
            wrongNumberValidation = localization["msg_Required"];
            
        }
        
        [IntlTelValidation]
        public  IntlTel number { set; get; }
    }
}
