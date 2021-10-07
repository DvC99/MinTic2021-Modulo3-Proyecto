using System;
using System.Collections.Generic;

#nullable disable

namespace Persistencia.DataBase
{
    public partial class Administrador
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public int IdAsignacion { get; set; }
    }
}
