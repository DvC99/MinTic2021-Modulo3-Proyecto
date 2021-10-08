using Paciente = Dominio.Paciente;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Persistencia.Logic
{
    public class PacienteLogic
    {
        MinTic2021Context minTic2021Context = new MinTic2021Context();

        public List<Paciente> getAllPacientes()
        {
            List<Paciente> pacientes = new List<Paciente>();
            var Listpacientes =  minTic2021Context.Pacientes.ToList();
            foreach (var pacientebd in Listpacientes)
            {
                Paciente paciente = new Paciente();
                paciente.Nombre1 = pacientebd.Nombre1;
                paciente.Nombre2 = pacientebd.Nombre2;
                paciente.Apellido1 = pacientebd.Apellido1;
                paciente.Apellido2 = pacientebd.Apellido2;
                paciente.Cedula = pacientebd.Cedula;
                paciente.Pasaporte = pacientebd.Pasaporte;

                pacientes.Add(paciente);
            }
            return pacientes;
        }
    }
}
