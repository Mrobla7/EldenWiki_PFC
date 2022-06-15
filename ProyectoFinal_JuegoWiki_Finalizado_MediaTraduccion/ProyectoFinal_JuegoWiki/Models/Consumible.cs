using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_JuegoWiki.Models
{
    public class Consumible
    {
        [Key]
        public int ConsumibleID { get; set; }
        [Column(TypeName = "Varchar(40)")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nombre { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Descripcion { get; set; }

        [Column(TypeName = "Varchar(300)")]
        [Display(Name = "Imagen")]
        [Required(ErrorMessage = "Imagen obligatoria")]
        public String Imagen { get; set; }
    }
}
