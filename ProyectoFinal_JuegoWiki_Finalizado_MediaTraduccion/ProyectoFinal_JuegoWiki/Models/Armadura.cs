using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_JuegoWiki.Models
{
    public class Armadura
    {
        [Key]
        public int ArmaduraID { get; set; }
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


        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(0, 2000, ErrorMessage = "El valor debe estar entre 0 y 2000")]
        public int Vitalidad { get; set; }


        [Column(TypeName = "decimal(4,1)")]
        [Display(Name = "Resistencia Física")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(-200, 200, ErrorMessage = "El valor debe estar entre -200 y 200")]
        public decimal ResFisica { get; set; }
        [Column(TypeName = "decimal(4,1)")]
        [Display(Name = "Resistencia Mágica")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(-200, 200, ErrorMessage = "El valor debe estar entre -200 y 200")]
        public decimal ResMagica { get; set; }
        [Column(TypeName = "decimal(4,1)")]
        [Display(Name = "Resistencia al Fuego")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(-200, 200, ErrorMessage = "El valor debe estar entre -200 y 200")]
        public decimal ResFuego { get; set; }
        [Column(TypeName = "decimal(4,1)")]
        [Display(Name = "Resistencia al Rayo")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(-200, 200, ErrorMessage = "El valor debe estar entre -200 y 200")]
        public decimal ResRayo { get; set; }
        [Column(TypeName = "decimal(4,1)")]
        [Display(Name = "Resistencia Sagrada")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(-200, 200, ErrorMessage = "El valor debe estar entre -200 y 200")]
        public decimal ResSagrado { get; set; }

        [Column(TypeName = "decimal(4,1)")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(0, 200, ErrorMessage = "El valor debe estar entre 0 y 200")]
        public decimal Peso { get; set; }
    }
}
