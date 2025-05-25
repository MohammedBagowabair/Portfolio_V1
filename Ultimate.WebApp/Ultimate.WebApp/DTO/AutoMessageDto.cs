using System.ComponentModel.DataAnnotations;
using Ultimate.Bot.Core.Model;
using Ultimate.WebApp.Model.Validations;
namespace Ultimate.Bot.Application.DTO
{
    public class AutoMessageDto
    {
        public int Id { get; set; }
        [RequiredAttr]
        public string Message { get; set; }
        public string initMsg { get; set; }
        public string MsgType { get; set; }
        public string Actionn { get; set; }
        public int BotId { get; set; }

    }
}
