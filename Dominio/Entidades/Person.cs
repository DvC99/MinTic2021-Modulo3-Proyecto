﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Person
    {
        //Scaffold-DbContext "Server=DANIELVALENCIA\MSSQLSERVER01;Database=MinTic2021;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DataBase
        //Scaffold-DbContext "Server=DANIELVALENCIA\MSSQLSERVER01;Database=MinTic2021;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DataBase -t table-name -force -verbose
        public int Id { get; set; }
        public string Nombre { get; set; }        
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public Genero Genero { get; set; }
        public string Cedula { get; set; }
        public string NumeroTelefono { get; set; }
        public string Dirreccion { get; set; }

    }

}
