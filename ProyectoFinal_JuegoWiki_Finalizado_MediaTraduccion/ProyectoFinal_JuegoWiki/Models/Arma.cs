using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_JuegoWiki.Models
{
    public class Arma
    {
        [Key]
        public int ArmaID { get; set; }
        [Column(TypeName = "Varchar(40)")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nombre { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Descripcion { get; set; }


        [Column(TypeName = "Varchar(300)")]
        [Display(Name = "Imagen")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public String Imagen { get; set; }


        [Display(Name = "Tipo de Arma")]
        public TipoArma TipoArma { get; set; }
        public int TipoArmaID { get; set; }
        public Ceniza Ceniza { get; set; }
        public int CenizaID { get; set; }





        [Display(Name = "Daño Físico")]
        [Range(0,2000, ErrorMessage ="El valor debe estar entre 0 y 2000")]
        public int? DmgFisico { get; set; }
        [Display(Name = "Daño Mágico")]
        [Range(0, 2000, ErrorMessage = "El valor debe estar entre 0 y 2000")]
        public int? DmgMagico { get; set; }
        [Display(Name = "Daño de Fuego")]
        [Range(0, 2000, ErrorMessage = "El valor debe estar entre 0 y 2000")]
        public int? DmgFuego { get; set; }
        [Display(Name = "Daño de Rayo")]
        [Range(0, 2000, ErrorMessage = "El valor debe estar entre 0 y 2000")]
        public int? DmgRayo { get; set; }
        [Display(Name = "Daño Sagrado")]
        [Range(0, 2000, ErrorMessage = "El valor debe estar entre 0 y 2000")]
        public int? DmgSagrado { get; set; }
        [Display(Name = "Daño Crítico")]
        [Range(0, 2000, ErrorMessage = "El valor debe estar entre 0 y 2000")]
        public int? DmgCritico { get; set; }


        [Display(Name = "Requerimiento de Fuerza")]
        [Range(0, 99, ErrorMessage = "El valor debe estar entre 0 y 99")]
        public int? RequerimientoStr { get; set; }
        [Display(Name = "Escalado de Fuerza")]
        [RegularExpression(@"^[SABCDE]$", ErrorMessage = "Las opciones son: S,A,B,C,D y E.")]
        public char? EscaladoStr { get; set; }


        [Display(Name = "Requerimiento de Destreza")]
        public int? RequerimientoDex { get; set; }
        [Display(Name = "Escalado de Destreza")]
        [RegularExpression(@"^[SABCDE]$", ErrorMessage = "Las opciones son: S,A,B,C,D y E.")]
        public char? EscaladoDex { get; set; }


        [Display(Name = "Requerimiento de Inteligencia")]
        [Range(0, 99, ErrorMessage = "El valor debe estar entre 0 y 99")]
        public int? RequerimientoInt { get; set; }
        [Display(Name = "Escalado de Inteligencia")]
        [RegularExpression(@"^[SABCDE]$", ErrorMessage = "Las opciones son: S,A,B,C,D y E.")]
        public char? EscaladoInt { get; set; }
        
        
        [Display(Name = "Requerimiento de Fe")]
        [Range(0, 99, ErrorMessage = "El valor debe estar entre 0 y 99")]
        public int? RequerimientoFe { get; set; }
        [Display(Name = "Escalado de Fe")]
        [RegularExpression(@"^[SABCDE]$", ErrorMessage = "Las opciones son: S,A,B,C,D y E.")]
        public char? EscaladoFe { get; set; }
        
        
        [Display(Name = "Requerimiento de Arcana")]
        [Range(0, 99, ErrorMessage = "El valor debe estar entre 0 y 99")]
        public int? RequerimientoArcana { get; set; }
        [Display(Name = "Escalado de Arcana")]
        [RegularExpression(@"^[SABCDE]$", ErrorMessage = "Las opciones son: S,A,B,C,D y E.")]
        public char? EscaladoArcana { get; set; }

        [Column(TypeName = "decimal(4,1)")]
        [Range(0, 200, ErrorMessage = "El valor debe estar entre 0 y 200")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public decimal Peso { get; set; }
    }
}
