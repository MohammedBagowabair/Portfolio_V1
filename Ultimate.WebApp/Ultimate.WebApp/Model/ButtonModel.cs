using System.ComponentModel.DataAnnotations.Schema;

namespace Ultimate.WebApp.Model
{
    public class ButtonModel
    {
        public int Id { get; set; }
        public string body { get; set; }
        public string title { get; set; }
        public string footer { get; set; }

        public string bodySpec { get; set; }

        public string action { get; set; }

        [ForeignKey("BotModel")]
        public int? BotId { get; set; }
        public virtual BotModel Bot { get; set; }

        [ForeignKey("ClientModel")]
        public int? ClientId { get; set; }
        public virtual ClientModel Claint { get; }
    }
}
