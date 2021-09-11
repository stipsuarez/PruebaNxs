using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNxs.Webapi.Dtos
{
    public class AutorDto
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(35)]
        public string Nombre { get; set; }
        [Required]
        public DateTime Fechanacimiento { get; set; }
        [Required]
        [MaxLength(25)]
        public string Ciudad { get; set; }
        [Required]
        [MaxLength(40)]
        public string Email { get; set; }
    }
}
