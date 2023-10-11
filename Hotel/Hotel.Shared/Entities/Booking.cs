using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Shared.Entities
{
   public class Booking
    {
        public int Id { get; set; }

        [Display(Name = "Reserva")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        public int amount_Adults { get; set; }

        public int amount_Children { get; set; }

        public int amount_Baby { get; set; }

        public ICollection<ServiceType>? ServiceTypes { get; set; }

        [Display(Name = "Servicio")]
        public int ServiceTypesNumber => ServiceTypes == null ? 0 : ServiceTypes.Count;
    }
}
