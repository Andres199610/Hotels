using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Shared.Entities
{
    public class RoomImage
    {

        public int Id { get; set; }

        public Room Room { get; set; } = null!;

        public int RoomId { get; set; }

        [Display(Name = "Imagen")]
        public string Image { get; set; } = null!;

    }
}
