using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNxs.Webapi
{
    public class LibroDto
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Titulo { get; set; }
        [Required]
        public int Nopaginas { get; set; }
        [Required]
        public int Ano { get; set; }
        [Required]
        [MaxLength(30)]
        public string Genero { get; set; }

        [Required]
        public int Idautor { get; set; }
    }
}
