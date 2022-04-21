using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Equipes
    {
        [Key]
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Setor {get; set;}
        

    }

}