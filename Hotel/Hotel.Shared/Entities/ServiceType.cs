using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Shared.Entities
{
    public class ServiceType
    {

        public int Id { get; set; }

        [Display(Name = "Tipo Servicio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Name { get; set; } = null!;
    }
}
