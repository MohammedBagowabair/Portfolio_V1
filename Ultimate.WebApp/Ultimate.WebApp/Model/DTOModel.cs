using System.ComponentModel.DataAnnotations;
using Ultimate.WebApp.Model.Validations;

namespace Ultimate.WebApp.Model
{
    public class DTOModel
    {
        public int id { get; set; }
        [RequiredAttr]
        //[Required]
        public string code { get; set; }
    }
}
