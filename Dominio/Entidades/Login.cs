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
        //[EmailAddress]
        public string Correo { get; set; }

        
        //[StringLength(100, MinimumLength = 10)]
        public string Password { get; set; }
    }
}
