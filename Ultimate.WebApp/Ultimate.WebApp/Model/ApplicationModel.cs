using System;
using Ultimate.WebApp.Model.Validations;
namespace Ultimate.WebApp.Model
{
    public class ApplicationModel
    {
        public int id { get; set; }
        [RequiredAttr]
        public string name { get; set; }
        public string secretKey { get; set; }
        [RequiredAttr]
        public DateTime? timeRefreshToken { get; set; }
        public string appId { get; set; }
        public string role { get; set; }
        public bool inactive { get; set; }
        public int clientId { get; set; }
        public virtual ClientModel ClientModels { get; set; }

    }
}
