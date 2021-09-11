using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PruebaNxs.Abstractions;
using PruebaNxs.Entities;

#nullable disable

namespace PruebaNxs.Models
{
    public class Autor : Entity
    {
        public Autor()
        {
            Libros = new HashSet<Libro>();
        }

        [Key]
        [Column("Idautor")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [MaxLength(35)]
        //[Column("Nombre")]
        public string Nombre { get; set; }
        [Required]
        //[Column("Fechanacimiento")]
        public DateTime Fechanacimiento { get; set; }
        [Required]
        [MaxLength(25)]
        //[Column("Ciudad")]
        public string Ciudad { get; set; }
        [Required]
        [MaxLength(40)]
        //[Column("Email")]
        public string Email { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
