﻿using Dominio;
using Dominio.Entidades;
using HospiEnCasa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Persistencia.Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static Dominio.Helper.Enum;

namespace HospiEnCasa.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HospiEnCasaLogic hospiLogic = new HospiEnCasaLogic();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Login(string loginError = "")
        {
            HttpContext.Session.Clear();

            if (!string.IsNullOrEmpty(loginError))
            {
                ViewBag.LoginError = loginError;
            }

            return View();
        }


        [HttpPost]
        public IActionResult Home(Login loginEntity)
        {
            if (hospiLogic.VefirySession(loginEntity))
            {
                HttpContext.Session.SetString("token", loginEntity.Correo);
                VerifySession();
            }
            else
            {
                return RedirectToAction("Login", "Home", routeValues: new { loginError = "El usuario no existe" });
            }
            return View();
        }

        // Crear los administradores
        [HttpPost]
        public IActionResult Signup(AdiministradorEntity admi)
        {
            List<SelectListItem> listGenero = new List<SelectListItem>();
            foreach(int item in Genero.GetValues(typeof(Genero)))
            {
                listGenero.Add(new SelectListItem { Value = ((int)item).ToString() , Text = Genero.ToObject(typeof(Genero), (int)item).ToString() });
            }

            ViewBag.ListCompanyDocumentType = listGenero;

            if (admi.Cedula!=null)
            {            
                var responseBase = hospiLogic.CreateAdministrador(admi);

                ViewBag.Message = responseBase.Message;
                ViewBag.Type = Enum.ToObject(typeof(TypeMessage), (int)responseBase.Type).ToString();
                if (responseBase.Type.ToString().Equals("success"))
                {
                    return View("Home");
                }
            }
            return View();
        }


        //[HttpPost]
        //public IActionResult SignupCreate(AdiministradorEntity admi)
        //{
        //    var responseBase = hospiLogic.CreateAdministrador(admi);

        //    ViewBag.Message = responseBase.Message;
        //    ViewBag.Type = Enum.ToObject(typeof(TypeMessage), (int)responseBase.Type).ToString();
        //    if (responseBase.Type.ToString().Equals("success"))
        //    {
        //        return View("Home");
        //    }
        //    return View();
        //}

        public IActionResult CreateAppointment()
        {
            VerifySession();
            return View();
        }

        public IActionResult Paciente()
        {
            return View();
        }

        public IActionResult Medico()
        {
            return View();
        }

        public IActionResult Enfermera()
        {
            return View();
        }


        private void VerifySession()
        {
            var session = HttpContext.Session.GetString("token");

            if (string.IsNullOrEmpty(session))
            {
                HttpContext.Session.Clear();
                ViewBag.LoginError = "El usuario no esta logeado";
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
