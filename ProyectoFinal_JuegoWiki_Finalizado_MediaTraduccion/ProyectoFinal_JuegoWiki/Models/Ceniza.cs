using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_JuegoWiki.Models
{
    public class Ceniza
    {
        [Key]
        public int CenizaID { get; set; }
        [Column(TypeName = "Varchar(40)")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nombre { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Descripcion { get; set; }
        [Display(Name = "Coste de maná")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(0, 200, ErrorMessage = "El valor debe estar entre 0 y 200")]
        public int CosteMana { get; set; }
    }
}
