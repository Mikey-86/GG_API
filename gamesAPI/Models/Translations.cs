using System.ComponentModel.DataAnnotations;

namespace gamesAPI.Models
{
    public class Translations
    {
        [Key]
        public int ID { get; set; }
        public string English { get; set; }
        public string Spanish { get; set; }
        public string French { get; set; }
        public string German { get; set; }
    }
}
