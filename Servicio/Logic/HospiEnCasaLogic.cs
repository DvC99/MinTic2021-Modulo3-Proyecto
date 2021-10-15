using Dominio;
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

        public ResponseBaseEntity CreateAdministrador(AdiministradorEntity adm)
        {
            using var dbContextTransaction = dbcontex.Database.BeginTransaction();
            try
            {
                var client = dbcontex.Administradors.Where(x => x.Cedula == adm.Cedula).FirstOrDefault();
                if (client != null)
                {
                    return GetResponseBaseEntity("Ya existe un usuario con esa cedula", TypeMessage.danger);
                }else if (dbcontex.Administradors.Where(x => x.Email == adm.Mail).FirstOrDefault() != null)
                {
                    return GetResponseBaseEntity("Ya existe un usuario con ese correo", TypeMessage.danger);
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

        public ResponseBaseEntity CrearPaciente(PacienteEntity pas, int idAdmi, int idFamiliar)
        {
            using var dbContextTransaction = dbcontex.Database.BeginTransaction();
            try
            {
                var client = dbcontex.Pacientes.Where(x => x.Cedula == pas.Cedula).FirstOrDefault();
                if (client != null)
                {
                    return GetResponseBaseEntity("Ya existe un Paciente con esa cedula", TypeMessage.danger);
                }

                Random rn = new();
                int random = rn.Next();
                var id = dbcontex.Pacientes.Where(x => x.Id == random).FirstOrDefault();
                while (id != null)
                {
                    random = rn.Next();
                    id = dbcontex.Pacientes.Where(x => x.Id == random).FirstOrDefault();
                }
                pas.Id = random;

                dbcontex.Pacientes.Add(ConvertPaceinteToPacienteDb(pas, idAdmi, idFamiliar));
                dbcontex.SaveChanges();
                dbContextTransaction.Commit();

                return GetResponseBaseEntity("Paciente creado con exito! ", TypeMessage.success);
            }
            catch (Exception e)
            {
                dbContextTransaction.Rollback();
                return GetResponseBaseEntity(e.Message, TypeMessage.danger);
            }
        }

        public ResponseBaseEntity CrearFamiliar(FamiliarDesigado fami)
        {
            using var dbContextTransaction = dbcontex.Database.BeginTransaction();
            try
            {
                var client = dbcontex.Familiars.Where(x => x.Cedula == fami.Cedula).FirstOrDefault();
                if (client != null)
                {
                    return GetResponseBaseEntity("Ya existe Familiar con esa cedula", TypeMessage.danger);
                }

                Random rn = new();
                int random = rn.Next();
                var id = dbcontex.Familiars.Where(x => x.Id == random).FirstOrDefault();
                while (id != null)
                {
                    random = rn.Next();
                    id = dbcontex.Familiars.Where(x => x.Id == random).FirstOrDefault();
                }
                fami.Id = random;

                dbcontex.Familiars.Add(ConvertirFamilirToFamiliarDb(fami));
                dbcontex.SaveChanges();
                dbContextTransaction.Commit();

                return GetResponseBaseEntity("Familiar creado con exito! ", TypeMessage.success);
            }
            catch (Exception e)
            {
                dbContextTransaction.Rollback();
                return GetResponseBaseEntity(e.Message, TypeMessage.danger);
            }
        }

        public ResponseBaseEntity CrearMedico(DoctorDesignado doc, int idAdmi)
        {
            using var dbContextTransaction = dbcontex.Database.BeginTransaction();
            try
            {
                var client = dbcontex.Medicos.Where(x => x.Cedula == doc.Cedula).FirstOrDefault();
                if (client != null)
                {
                    return GetResponseBaseEntity("Ya existe un Medico con esa cedula", TypeMessage.danger);
                }

                Random rn = new();
                int random = rn.Next();
                var id = dbcontex.Medicos.Where(x => x.Id == random).FirstOrDefault();
                while (id != null)
                {
                    random = rn.Next();
                    id = dbcontex.Medicos.Where(x => x.Id == random).FirstOrDefault();
                }
                doc.Id = random;

                dbcontex.Medicos.Add(ConvertirMedicoToMedicoDb(doc, idAdmi));
                dbcontex.SaveChanges();
                dbContextTransaction.Commit();

                return GetResponseBaseEntity("Medico creado con exito! ", TypeMessage.success);
            }
            catch (Exception e)
            {
                dbContextTransaction.Rollback();
                return GetResponseBaseEntity(e.Message, TypeMessage.danger);
            }
        }

        public ResponseBaseEntity CrearEnfermera(EnfermeraDesignada enf, int idAdmi)
        {
            using var dbContextTransaction = dbcontex.Database.BeginTransaction();
            try
            {
                var client = dbcontex.Enfermeras.Where(x => x.Cedula == enf.Cedula).FirstOrDefault();
                if (client != null)
                {
                    return GetResponseBaseEntity("Ya existe una Enfermera con esa cedula", TypeMessage.danger);
                }

                Random rn = new();
                int random = rn.Next();
                var id = dbcontex.Enfermeras.Where(x => x.Id == random).FirstOrDefault();
                while (id != null)
                {
                    random = rn.Next();
                    id = dbcontex.Enfermeras.Where(x => x.Id == random).FirstOrDefault();
                }
                enf.Id = random;

                dbcontex.Enfermeras.Add(ConvertirEnfermeraToEnfermeraDb(enf, idAdmi));
                dbcontex.SaveChanges();
                dbContextTransaction.Commit();

                return GetResponseBaseEntity("Enfermera creado con exito! ", TypeMessage.success);
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

        private static Paciente ConvertPaceinteToPacienteDb(PacienteEntity pas, int idAdmi, int idFamiliar)
        {
            Paciente paciente = new() {
                Id = pas.Id,
                Cedula = pas.Cedula,
                IdAdministrador = idAdmi,
                IdFamiliar = idFamiliar,
                Nombre = pas.Nombre,
                Apellido = pas.Apellido,                
                Edad = pas.Edad,                
                Genero = pas.Genero.ToString(),
                Telefono = pas.NumeroTelefono
            };
            return paciente;
        }

        private static Familiar ConvertirFamilirToFamiliarDb(FamiliarDesigado fami)
        {
            Familiar familiar = new() {
                Id =  fami.Id,
                Nombre = fami.Nombre,
                Apellido = fami.Apellido,
                Cedula = fami.Cedula,
                Edad = fami.Edad,
                Parentesco = fami.Parentesco,
                Genero = fami.Genero.ToString(),
                Telefono = fami.NumeroTelefono                
            };
            return familiar;
        }
        
        private static Medico ConvertirMedicoToMedicoDb(DoctorDesignado doc, int idAdmi)
        {
            Medico medico = new()
            {
                Id =  doc.Id,
                Nombre = doc.Nombre,
                Apellido = doc.Apellido,
                Cedula = doc.Cedula,
                Edad = doc.Edad,
                Especialidad = doc.Especialidad,
                IdAdministrador = idAdmi,
                Genero = doc.Genero.ToString(),
                Telefono = doc.NumeroTelefono
            };
            return medico;
        }

        private static Enfermera ConvertirEnfermeraToEnfermeraDb(EnfermeraDesignada enf, int idAdmi)
        {
            Enfermera enfermera = new()
            {
                Id =  enf.Id,
                Nombre = enf.Nombre,
                Apellido = enf.Apellido,
                Cedula = enf.Cedula,
                Edad = enf.Edad,
                Especialidad = enf.Especialidad,
                IdAdministrador = idAdmi,
                Genero = enf.Genero.ToString(),
                Telefono = enf.NumeroTelefono
            };
            return enfermera;
        }

        public int IdAdmi(String correo)
        {
            var Admi = dbcontex.Administradors.Where(x => x.Email == correo).FirstOrDefault();
            if (Admi == null)
            {
                return -1;
            }
            return Admi.Id;
        }

        public List<Familiar> ListFamiliarDB()
        {
            return dbcontex.Familiars.ToList();
        }

        public bool VefirySession(Login loginEntity)
        {
            var client = dbcontex.Administradors.Where(x => x.Email.Equals(loginEntity.Correo)).FirstOrDefault();
            if (client == null) return false;
            var admin = dbcontex.Administradors.Where(x => x.Email.Equals(loginEntity.Correo) && x.Contra.Equals(loginEntity.Password)).FirstOrDefault();
            if (admin == null) return false;
            return true;
        }
    }
}
