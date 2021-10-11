using Dominio.Entidades;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dominio.Helper.Enum;

namespace Persistencia.Logic
{
    public class HospiEnCasaLogic
    {
       private readonly MinTic2021Context dbcontex = new();

        public bool VefirySession(Login loginEntity)
        {
            var client = dbcontex.Administradors.Where(x => x.Email.Equals(loginEntity.Correo)).FirstOrDefault();
            if (client == null) return false;
            var admin = dbcontex.Administradors.Where(x => x.Email.Equals(loginEntity.Correo) && x.Contra.Equals(loginEntity.Password)).FirstOrDefault();
            if (admin == null) return false;
            return true;
        }

        public ResponseBaseEntity CreateAdministrador(AdiministradorEntity adm)
        {
            using var dbContextTransaction = dbcontex.Database.BeginTransaction();
            try
            {
                var client = dbcontex.Administradors.Where(x => x.Cedula == adm.Cedula).FirstOrDefault();
                if (client != null)
                {
                    return GetResponseBaseEntity("Ya existe un usuario con esa cedula", TypeMessage.danger);
                }

                Random rn = new();
                int random = rn.Next();
                var id = dbcontex.Administradors.Where(x => x.Id == random).FirstOrDefault();
                while (id != null)
                {
                    random = rn.Next();
                    id = dbcontex.Administradors.Where(x => x.Id == random).FirstOrDefault();
                }
                adm.Id = random;

                dbcontex.Administradors.Add(ConvertAdmisnistradorToAdministradorDb(adm));
                dbcontex.SaveChanges();
                dbContextTransaction.Commit();

                return GetResponseBaseEntity("Usuario administrador creado con exito! ", TypeMessage.success);

            }
            catch (Exception e)
            {
                dbContextTransaction.Rollback();
                return GetResponseBaseEntity(e.Message, TypeMessage.danger);
            }
        }


        private static ResponseBaseEntity GetResponseBaseEntity(string message, TypeMessage typeMessage)
        {
            ResponseBaseEntity responseBaseEntity = new();
            responseBaseEntity.Message = message;
            responseBaseEntity.Type = typeMessage;
            return responseBaseEntity;
        }

        private static Administrador ConvertAdmisnistradorToAdministradorDb(AdiministradorEntity adm)
        {
           
            Administrador administrador = new()
            {
                Id =  adm.Id,
                Nombre = adm.Nombre,
                Apellido = adm.Apellido,
                Cedula = adm.Cedula,
                Edad = adm.Edad,
                Email = adm.Mail,
                Contra = adm.Password,
                Genero = adm.Genero.ToString(),
                Telefono = adm.NumeroTelefono,
                Cargo = adm.Cargo
            };

            return administrador;
        }

    }
}
