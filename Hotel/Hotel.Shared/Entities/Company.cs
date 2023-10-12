using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Shared.Entities
{
   public class Company
    {

        public int Id { get; set; }

        [Display(Name = "Cancelacion")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Name { get; set; } = null!;
        public ICollection<Room>? Rooms { get; set; }

        [Display(Name = "Habitacion")]
        public int RoomsNumber => Rooms == null ? 0 : Rooms.Count;
    }
}

