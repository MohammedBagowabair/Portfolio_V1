using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;
using Ultimate.WebApp.Interface;
using Ultimate.WebApp.Model.Validations;
using Ultimate.WebApp.Pages;
using Ultimate.WebApp.Service;
using Ultimate.WebApp.Shared.ResourceFiles;

namespace Ultimate.WebApp.Model
{
    public class ClientModel
    {

        public int Id { get; set; }
        [RequiredAttr]
        public string Name { get; set; }
        [RequiredAttr]
        
        public string Description { get; set; }
        [RequiredAttr]
        
        //[Phone]
        public string WhatsappNumber { get; set; }
        [RequiredAttr]

        public bool Inactive { set; get; }
        
        public string Icon { get; set; }
        public string Qr { get; set; }
        public string ActiveType { get; set; }
        public string ActiveName { get; set; }
        [RequiredAttr]
        public string NameAdmin { get; set; }
        [RequiredAttr]
       
        public string PhoneAdmin { get; set; }
        public int UserId { get; set; }
        public virtual UserModel UserModel { get; set; }
        public virtual ICollection<BotModel> Bots { get; set; } = new List<BotModel>();
        public bool isConnected { get; set; } = false;
       
       
    }
}
