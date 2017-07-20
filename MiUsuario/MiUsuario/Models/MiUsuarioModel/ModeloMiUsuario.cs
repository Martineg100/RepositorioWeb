using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiUsuario.Models.MiUsuarioModel
{
    public class ModeloMiUsuario
    {
        int IdUsuario { get; set; }
        string Referencia { get; set; }
        string Usuario { get; set; }
        string Contrasena { get; set; }
        string Pagina { get; set; }
        string Logo { get; set; }

    }
}