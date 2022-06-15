using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_JuegoWiki.Models
{
    public class ArmaViewModel
    {
        public List<Arma> Arma { get; set; }
        public SelectList Ceniza { get; set; }
        public SelectList TipoArma { get; set; }
        public string? BuscarArma { get; set; }
    }
}
