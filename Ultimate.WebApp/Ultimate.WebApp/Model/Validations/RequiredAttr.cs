using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;
using Ultimate.WebApp.Service;
using Ultimate.WebApp.Shared.ResourceFiles;

namespace Ultimate.WebApp.Model.Validations
{
    public class RequiredAttr:RequiredAttribute
    {
        public RequiredAttr()
        {
            var localization = Global.Services.GetRequiredService<IStringLocalizer<Resource>>();
            this.ErrorMessage =  localization["msg_Required"] ;
            
        }

    }
}
