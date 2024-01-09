using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Message
    {
        public int Id { get; set; }
        
        public string Emeteur { get; set; }
        public string Contenu { get; set; }
        public string Date { get; set; }
    }
}
