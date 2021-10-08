using Microsoft.AspNetCore.Mvc;
using Persistencia.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospiEnCasa.Controllers
{
    public class PacienteController : Controller
    {
        public IActionResult pacientes()
        {
            PacienteLogic paciente=new PacienteLogic();
            return View(paciente.getAllPacientes());
        }
    }
}
