using Microsoft.AspNetCore.Mvc;
using CRUDCORE.Datos;
using CRUDCORE.Models;

namespace CRUDCORE.Controllers
{
    public class MantenedorContactoController : Controller
    {
        ContactoDatos contactoDatos = new ContactoDatos();//Creamos objeto de tipo ContactoDatos
        public IActionResult Listar()
        {
            //La vista mostrará una lista de contactos
            var oLista = contactoDatos.Listar();//Nos devuelve toda la lista de contactos en la tabla
            return View(oLista);
        }
        //Se hace sobrecarga de métodos ya que uno sirve para mostrar el formulario y el otro para recibir el objeto e interactuar con la BD
        public IActionResult Guardar()
        {
            //Mostrar formulario guardar
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)//Obtener los datos del formulario y enviar a la base de datos
        {
            //Recibe un objeto y lo guarda en la base de datos
            if (!ModelState.IsValid)//Validamos si las validaciones [required] son incorrectas por eso el !
                return View();//Si no se cumplen las validaciones nos devuelve a la misma vista

            var respuesta = contactoDatos.Guardar(oContacto);

            if (respuesta)
            {
                return RedirectToAction("Listar");//Si se guarda el contacto nos devuelve a la lista
            }
            else
            {
                return View();//Nos va a devolver esta misma vista
            }
        }

        public IActionResult Editar(int contactoID)
        {
            //Mostrar formulario guardar
            var oContacto = contactoDatos.Obtener(contactoID);
            return View(oContacto);
        }
        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)//Obtener los datos del formulario y enviar a la base de datos
        {
            //Recibe un objeto y lo guarda en la base de datos
            if (!ModelState.IsValid)//Validamos si las validaciones [required] son incorrectas por eso el !
                return View();//Si no se cumplen las validaciones nos devuelve a la misma vista

            var respuesta = contactoDatos.Editar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");//Si se guarda el contacto nos devuelve a la lista
            else
                return View();//Nos va a devolver esta misma vista
        }

        public IActionResult Eliminar(int contactoID)
        {
            //Mostrar formulario guardar
            var oContacto = contactoDatos.Obtener(contactoID);
            return View(oContacto);
        }
        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto)//Obtener los datos del formulario y enviar a la base de datos
        {
            //Recibe un objeto y lo guarda en la base de datos
            var respuesta = contactoDatos.Eliminar(oContacto.contactoID);

            if (respuesta)
                return RedirectToAction("Listar");//Si se guarda el contacto nos devuelve a la lista
            else
                return View();//Nos va a devolver esta misma vista
        }
    }
}
