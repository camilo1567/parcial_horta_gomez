using System.ComponentModel.DataAnnotations;

namespace parcial_Horta_Gomez.Models
{
    public class User
    {

        public string Name { get; set; }
        public int Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
