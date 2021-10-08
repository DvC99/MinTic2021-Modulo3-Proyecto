using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Login
    {
        [Required(ErrorMessage = "Identificacion Requerida")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Contraseña Requerida")]
        public string Passwork { get; set; }
    }
}
