using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using waMusicPro.Models;
using System.Threading.Tasks;
using waMusicPro.Data;
using System.Net.NetworkInformation;


namespace waMusicPro.Controllers
{
    public class AdminController : Controller
    {
        //List<Models.Producto> lista;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        // GET: Admin
        public ActionResult Index() { 
                if (Session["Usuario"] == null)
                {
                    return RedirectToAction("LoginIndex", "Login");
                }
                UserModel usuario = Session["Usuario"] as UserModel;
        
        
                return View();
                }
        public ActionResult AddProducts()
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("LoginIndex", "Login");
            }
            return View();
        }

        public ActionResult EditProducts(int id)
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("LoginIndex", "Login");
            }
            var listaP = Data.Productos.Listar();

            return View(listaP.FirstOrDefault(_ => _.ProductoId == id));
        }

        public ActionResult Products()
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("LoginIndex", "Login");
            }
            var lista = Data.Productos.Listar();

            return View(lista);
        }

        public ActionResult Users()
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("LoginIndex", "Login");
            }
            var lista = Data.Usuarios.Listar();

            return View(lista);
        }

        public ActionResult AddUsers()
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("LoginIndex", "Login");
            }
            return View();
        }

        public ActionResult EditUser(string username)
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("LoginIndex", "Login");
            }
            var listaU = Data.Usuarios.Listar();

            return View(listaU.FirstOrDefault(_ => _.Username == username));
        }

        // DELETE: Admin
        public ActionResult DeleteProducts(int id)
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("LoginIndex", "Login");
            }
            // Create a new instance of the Producto class with the specified ID
            Producto productoAEliminar = new Producto
            {
                ProductoId = id
            };

            // Attempt to delete the product
            bool resultado = Data.Productos.Eliminar(productoAEliminar);

            if (resultado)
            {
                // Product deleted successfully
                TempData["SuccessMessage"] = "Product deleted successfully.";
            }
            else
            {
                // Error occurred while deleting the product
                TempData["ErrorMessage"] = "An error occurred while deleting the product.";
            }

            // Redirect to the Products action to display the updated list
            return RedirectToAction("Products");
        }
        public ActionResult Logout()
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("LoginIndex", "Login");
            }
            Session.Abandon();
            return RedirectToAction("index", "HomeController");
        }
        public ActionResult Details(int id)
        {
            var lista = Data.Productos.Listar();
            return View(lista.FirstOrDefault(_ => _.ProductoId == id));
        }
    }
}//Alfredito was here
