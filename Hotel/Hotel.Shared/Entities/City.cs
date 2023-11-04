using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Hotel.Shared.Entities
{
    public class City
    {
        public int Id { get; set; }

        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Name { get; set; } = null!;
        public int StateId { get; set; }


        [JsonIgnore]
        public State State { get; set; } = null!;

        public ICollection<User>? Users { get; set; }
    }
}
