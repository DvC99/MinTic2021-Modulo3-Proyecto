using Dominio.Entidades;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Logic
{
    public class HospiEnCasa
    {
        MinTic2021Context dbcontex = new MinTic2021Context();

        public bool VefirySession(Login loginEntity)
        {
            var client = dbcontex.Administradors.Where(x => x.Email.Equals(loginEntity.Correo)).FirstOrDefault();
            if (client == null) return false;
            var admin = dbcontex.Administradors.Where(x => x.Email.Equals(loginEntity.Correo) && x.Contra.Equals(loginEntity.Passwork)).FirstOrDefault();
            if (admin == null) return false;
            return true;
        }

        public ResponseBaseEntity CreateClient(ClientEntity clientEntity)
        {

        }





        private Administrador ConvertAdmisnistradorToAdministradorDb (AdiministradorEntity adm)
        {
            Administrador administrador = new Administrador();
            administrador.Nombre = adm.Nombre;
            administrador.Apellido = adm.Apellido;
            administrador.Cedula = adm.Cedula;
            administrador.Edad = adm.Edad;
            administrador.Email = adm.Mail;
            administrador.Contra = adm.Passwork;


            return administrador;
        }

    }
}
