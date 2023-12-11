

using Microsoft.AspNetCore.Mvc;
using CRUDCORE.Datos;
using CRUDCORE.Models;

namespace CRUDCORE.Controllers
{
    public class MantenedorController : Controller
    {
        RegistroDatos _registroDatos = new RegistroDatos();

        public IActionResult Listar()
        {
            //la vista mostrara la lista de peliculas

            var Olista = _registroDatos.Listar();
            return View(Olista);
        }
        public IActionResult Guardar()
        {
            //devolvera la vista
            return View();
        }


        [HttpPost]
        public IActionResult Guardar(RegistroModel Oregistro)
        {
            //recibir un objeto y guardarlo

            if (!ModelState.IsValid)
            {

                return View();
            }
            var respuesta = _registroDatos.Guardar(Oregistro);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
                return View();
        }
        public IActionResult Editar(int idRegistro)
        {
            //devolvera la vista
            var Oregistro = _registroDatos.Obtener(idRegistro);
            return View(Oregistro);
        }
        [HttpPost]
        public IActionResult Editar(RegistroModel Oregistro)
        {
            if (!ModelState.IsValid)
            {

                return View();
            }
            var respuesta = _registroDatos.Editar(Oregistro);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
                return View();


        }
        public IActionResult Eliminar(int idRegistro)
        {
            //devolvera la vista
            var Oregistro = _registroDatos.Obtener(idRegistro);
            return View(Oregistro);
        }
        [HttpPost]
        public IActionResult Eliminar(RegistroModel Oregistro)
        {
           
            var respuesta = _registroDatos.Eliminar(Oregistro.idRegistro);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
                return View();


        }

    }
}
