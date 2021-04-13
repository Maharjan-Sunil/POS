using Neodynamic.SDK.Web;
using System.Web.Mvc;

public class HomeController : Controller
{
    public ActionResult Index()
    {

        ViewBag.WCPPDetectionScript = WebClientPrint.CreateWcppDetectionScript(Url.Action("ProcessRequest", "WebClientPrintAPI", null, HttpContext.Request.Url.Scheme),
                                                                                HttpContext.Session.SessionID);
        return View();
    }

}