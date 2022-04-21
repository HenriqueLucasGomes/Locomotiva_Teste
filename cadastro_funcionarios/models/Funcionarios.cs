using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Funcionarios
    {
        [Key]
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Cargo {get; set;}
        public string Email {get; set;}
        public string Equipe {get; set;}

    }

}