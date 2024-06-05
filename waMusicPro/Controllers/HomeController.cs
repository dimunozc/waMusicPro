using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Transbank.Common;
using Transbank.Webpay.Common;
using Transbank.Webpay.WebpayPlus;



namespace waMusicPro.Controllers
{
    public class HomeController : Controller
    {
        //List<Models.Producto> lista;

        protected override void Initialize(RequestContext requestContext)
        {
            var lista = Data.Productos.Listar();

            base.Initialize(requestContext);
        }

        public ActionResult Inicio()
        {
            
            // Versión 4.x del SDK
            var tx = new Transaction(new Options(IntegrationCommerceCodes.WEBPAY_PLUS, IntegrationApiKeys.WEBPAY, WebpayIntegrationType.Test));
            var buyOrder = "1001";
            var sessionId = "23456";
            var amount = 999;
            var returnUrl = "http://localhost:50550/Home/Webpay";

            var response = tx.Create(buyOrder, sessionId, amount, returnUrl);

            ViewBag.Url = response.Url;
            ViewBag.Token = response.Token;

            return View();
        }

        public ActionResult WP_carrito(int monto)
        {

            // Versión 4.x del SDK
            var tx = new Transaction(new Options(IntegrationCommerceCodes.WEBPAY_PLUS, IntegrationApiKeys.WEBPAY, WebpayIntegrationType.Test));
            var buyOrder = "1001";
            var sessionId = "23456";
            var amount = monto;
            var returnUrl = "http://localhost:50550/Home/Webpay";
            //encapsular en un try catch
            var response = tx.Create(buyOrder, sessionId, amount, returnUrl);

            ViewBag.Monto = amount;
            ViewBag.Url = response.Url;
            ViewBag.Token = response.Token;

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Products2()
        {
            // URL de la API
            string url = "https://si3.bcentral.cl/SieteRestWS/SieteRestWS.ashx?user=206037385&pass=nDJccXE0m17X&firstdate=&lastdate=&timeseries=F073.TCO.PRE.Z.D&function=GetSeries";

            try
            {
                // Realizar la petición GET a la API
                WebClient client = new WebClient();
                string response = client.DownloadString(url);

                // Decodificar la respuesta JSON
                dynamic data = JsonConvert.DeserializeObject(response);

                // Declarar una variable para almacenar el valor del cambio de dólar
                decimal dollarValue = 0;

                // Verificar si la respuesta contiene datos válidos
                if (data != null && data.Codigo == 0 && data.Series != null && data.Series.Obs != null)
                {
                    // Acceder al primer valor de la tasa de cambio (dólar)
                    dynamic firstObservation = data.Series.Obs[0];
                    dollarValue = firstObservation.value;
                }
                else
                {
                    ViewBag.ErrorMessage = "No se recibieron datos válidos de la API.";
                }

                // Pasar el valor del cambio de dólar a la vista
                ViewBag.DollarValue = dollarValue;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error en la petición: " + ex.Message;
            }

            var lista = Data.Productos.Listar();
            return View(lista);
        }

        public ActionResult Webpay()
        {
            var token = Request.Params["token_ws"];

            var tx = new Transaction(new Options(IntegrationCommerceCodes.WEBPAY_PLUS, IntegrationApiKeys.WEBPAY, WebpayIntegrationType.Test));
            var response = tx.Commit(token);

            var redirect = string.Empty;

            if (response.ResponseCode == 0 && response.Status == "AUTHORIZED")
                redirect = "Exito";
            else
                redirect = "Fracaso";

            return RedirectToAction(redirect);
        }
        public ActionResult Exito()
        {
            return View();

        }
        public ActionResult Fracaso()
        {
            return View();

        }

    }
}