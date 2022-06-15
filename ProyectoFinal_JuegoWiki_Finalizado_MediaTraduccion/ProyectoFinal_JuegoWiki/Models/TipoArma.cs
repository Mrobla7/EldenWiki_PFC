using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_JuegoWiki.Models
{
    public class TipoArma
    {
        [Key]
        public int TipoArmaID {get; set;}
        public string Nombre { get; set; }
    }
}
