using System.ComponentModel.DataAnnotations;
using Ultimate.WebApp.Model.Validations;
namespace Ultimate.WebApp.Model
{
    public class AutoMessageModel
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string InitMsg { get; set; }

        [RequiredAttr]
        public string ClientMessage { get; set; }

        public string Message { get; set; }

        public string MsgDescryption { get; set; }

        public string MsgType { get; set; }

        public string Hasback { get; set; }
        
        public string Actionn { get; set; }

        public int BotId { get; set; }
        public virtual BotModel BotModels { get; set; }

    }
}
