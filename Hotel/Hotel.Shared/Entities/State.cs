using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Hotel.Shared.Entities
{
    public class State
    {
        public int Id { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Name { get; set; } = null!;

        [JsonIgnore]

        public int CountryId { get; set; }
        [JsonIgnore]

        public Country Country { get; set; }
        [JsonIgnore]

        public ICollection<City>? Cities { get; set; }

        [Display(Name = "Ciudades")]
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;

    }
}
