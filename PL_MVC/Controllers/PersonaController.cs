using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = PruebaOracle.Persona.GetAll();

            ML.Persona persona = new ML.Persona();
            if (result.Correct)
            {
                persona.Personas = result.Objects;
                return View(persona);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al obtener la informacion" + result.ErrorMessage;
                return PartialView("ValidationModal");
            }

        }

        [HttpGet]
        public ActionResult Form(int? IdPersona) //Add { Id null } //Update {Id > 0 }
        {
            ML.Persona persona = new ML.Persona();

            if (IdPersona == null)
            {
                persona.Action = "Add";
                return View(persona);
            }
            else
            {
                //Upadate
                ML.Result result = PruebaOracle.Persona.GetById(IdPersona.Value);

                if (result.Correct)
                {
                    persona.Action = "Update";
                    persona.IdPersona = ((ML.Persona)result.Object).IdPersona;
                    persona.Nombre = ((ML.Persona)result.Object).Nombre;
                    persona.ApellidoPaterno = ((ML.Persona)result.Object).ApellidoPaterno;
                    persona.ApellidoMaterno = ((ML.Persona)result.Object).ApellidoMaterno;
                   


                    return View(persona);

                }
                else
                {
                    ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                    return PartialView("ValidationModal");
                }
            }


        }



        [HttpPost]
        public ActionResult Form(ML.Persona persona) //Add { Id null } //Update {Id > 0 }
        {
            ML.Result result = new ML.Result();

            if (persona.Action == "Add")
            {
                result = PruebaOracle.Persona.Add(persona);
                if (result.Correct)
                {
                    ViewBag.Message = "usuario agregada correctamente";
                }
            }
            else
            {
                result = PruebaOracle.Persona.Update(persona);
                if (result.Correct)
                {
                    ViewBag.Message = "usuario actualizada correctamente";
                }
            }

            if (!result.Correct)
            {
                ViewBag.Message = "No se pudo agregar correctamente el usuario " + result.ErrorMessage;
            }

            return PartialView("ValidationModal");

        }

        [HttpGet]
        public ActionResult Delete(int IdPersona)
        {
            ML.Persona persona = new ML.Persona();
            persona.IdPersona = IdPersona;

            ML.Result result = PruebaOracle.Persona.Delete(persona);

            if (result.Correct)
            {
                return RedirectToAction("GetAll");
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al eliminar" + result.ErrorMessage;
                return PartialView("ValidationModal");
            }
        }

        [HttpPost]
        public ActionResult CargaMasiva()
        {
            HttpPostedFileBase file = Request.Files["ArchivoTXT"];
            ML.Result resultCarga = new ML.Result();
            try
            {
                if (file.ContentLength > 0)
                {
                    var lines = new List<string>();

                    using (StreamReader reader = new StreamReader(file.InputStream))
                    {
                        bool PassFirsLine = false;
                        do
                        {
                            string textLine = reader.ReadLine();
                            string[] datosPersona = textLine.Split('|');

                            if (PassFirsLine)
                            {
                                ML.Persona persona = new ML.Persona();
                                persona.IdPersona = int.Parse(datosPersona[0]);
                                persona.Nombre = datosPersona[1];
                                persona.ApellidoPaterno = datosPersona[2];
                                //empleado.FechaControl = DateTime.ParseExact(datosEmpleado[3], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                                persona.ApellidoMaterno= datosPersona[4];


                                ML.Result result = PruebaOracle.Persona.Add(persona);


                                if (result.Correct)
                                {
                                    result.Correct = true;
                                    ViewBag.Message = "Usuarios asignados correctamente";
                                }
                                else
                                {
                                    result.Correct = false;
                                }
                            }
                            else
                            {
                                PassFirsLine = true;
                            }

                        } while (reader.Peek() != -1);
                    }

                }
            }
            catch (Exception ex)
            {
                resultCarga.Correct = false;
                resultCarga.ErrorMessage = ex.Message;
                resultCarga.Ex = ex;

            }

            return PartialView("ValidationModal");

        }

    }
}