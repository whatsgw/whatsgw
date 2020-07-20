using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace webhook.Controllers
{
    public class WhatsGWController : Controller
    {
        [HttpPost]
        public async Task<System.Web.Mvc.ActionResult> Events()
        {
            try
            {


                Stream req = Request.InputStream;
                req.Seek(0, System.IO.SeekOrigin.Begin);
                string json = new StreamReader(req).ReadToEnd();


                System.Collections.Specialized.NameValueCollection qscoll = System.Web.HttpUtility.ParseQueryString(json);

                string pars = "";
                foreach (string q in qscoll)
                    pars += q + ": " + qscoll[q] + "\n";

                string receviedpars = "Parametros:\n" + pars;

                return Json(receviedpars, "", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return base.Json(ex.Message, "", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            }
        }


    }
}