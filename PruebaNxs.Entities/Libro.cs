using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PruebaNxs.Entities;

#nullable disable

namespace PruebaNxs.Models
{
    public class Libro :Entity
    {
        [Key]
        [Column("IdLibro")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [ForeignKey("Idautor")]
        public virtual Autor IdautorNavigation { get; set; }
    }
}
