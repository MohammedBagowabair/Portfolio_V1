using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ultimate.Bot.Application.DTO
{
    public class ClientDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; } = "";
        public int? WhatsappNumber { get; set; }

        [DefaultValue(false)]
        public bool Inactive { get; set; }

        public string Icon { get; set; } = "";

        public string ActiveType { get; set; } = "";
        public string ActiveName { get; set; } = "";
        public string NameAdmin { get; set; } = "";
        public int? PhoneAdmin { get; set; }

        [Required]
        public int UserId { get; set; }

    }
}
