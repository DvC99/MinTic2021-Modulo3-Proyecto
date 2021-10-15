using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Person
    {
        //Scaffold-DbContext "Server=DANIELVALENCIA\MSSQLSERVER01;Database=MinTic2021;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DataBase
        //Scaffold-DbContext "Server=DANIELVALENCIA\MSSQLSERVER01;Database=MinTic2021;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DataBase -force 
        //Scaffold-DbContext "Server=DANIELVALENCIA\MSSQLSERVER01;Database=MinTic2021;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DataBase -force
        [Required(ErrorMessage = "Identificacion Requerida")]
        [RegularExpression("[0-9]*")]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre Requerido")]
        public string Nombre { get; set; }
       
        [Required(ErrorMessage = "Apellido Requerido")]
        public string Apellido { get; set; }
        
        public int Edad { get; set; }
        public Genero Genero { get; set; }
        public string Cedula { get; set; }
        public string NumeroTelefono { get; set; }

        [Required(ErrorMessage = "Contraseña Requerida")]
        [StringLength(100, MinimumLength = 10)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Correo Requerido")]
        [EmailAddress]
        public string Mail { get; set; }

    }

}
