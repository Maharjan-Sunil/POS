using Neodynamic.SDK.Web;
using System.Web.Mvc;
using ThermalPrinter.Models.DataManager;

public class PrintESCPOSController : Controller
{
    private readonly InvoiceDataManager _invoiceDataManager;

    public PrintESCPOSController()
    {
        _invoiceDataManager = new InvoiceDataManager();
    }
    public ActionResult Index()
    {
        ViewBag.WCPScript = WebClientPrint.CreateScript(Url.Action("ProcessRequest", "WebClientPrintAPI", null, HttpContext.Request.Url.Scheme),
                                                        Url.Action("PrintCommands", "PrintESCPOS", null, HttpContext.Request.Url.Scheme),
                                                        HttpContext.Session.SessionID);

        return View();
    }

    [AllowAnonymous]
    public void PrintCommands(string useDefaultPrinter, string printerName, int orderId)
    {
        var listOfItems = _invoiceDataManager.GetInvoiceByOrderId(orderId);
        //Create ESC/POS commands for sample receipt
        string ESC = "0x1B"; //ESC byte in hex notation
        string NewLine = "0x0A"; //LF byte in hex notation

        string cmds = ESC + "@"; //Initializes the printer (ESC @)
        cmds += ESC + "!" + "0x38"; //Emphasized + Double-height + Double-width mode selected (ESC ! (8 + 16 + 32)) 56 dec => 38 hex
        cmds += "BEST DEAL STORES"; //text to print
        cmds += NewLine + NewLine;
        cmds += ESC + "!" + "0x00"; //Character font A selected (ESC ! 0)
        cmds += "COOKIES                   5.00";
        cmds += NewLine;
        cmds += "MILK 65 Fl oz             3.78";
        cmds += NewLine + NewLine;
        cmds += "SUBTOTAL                  8.78";
        cmds += NewLine;
        cmds += "TAX 5%                    0.44";
        cmds += NewLine;
        cmds += "TOTAL                     9.22";
        cmds += NewLine;
        cmds += "CASH TEND                10.00";
        cmds += NewLine;
        cmds += "CASH DUE                  0.78";
        cmds += NewLine + NewLine;
        cmds += ESC + "!" + "0x18"; //Emphasized + Double-height mode selected (ESC ! (16 + 8)) 24 dec => 18 hex
        cmds += "# ITEMS SOLD 2";
        cmds += ESC + "!" + "0x00"; //Character font A selected (ESC ! 0)
        cmds += NewLine + NewLine;
        cmds += "11/03/13  19:53:17";


        //Create a ClientPrintJob and send it back to the client!
        ClientPrintJob cpj = new ClientPrintJob();
        //set  ESCPOS commands to print...
        cpj.PrinterCommands = cmds;
        cpj.FormatHexValues = true;

        //set client printer...
        if (useDefaultPrinter == "checked" || printerName == "null")
            cpj.ClientPrinter = new DefaultPrinter();
        else
            cpj.ClientPrinter = new InstalledPrinter(printerName);

        //send it...
        System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";
        System.Web.HttpContext.Current.Response.BinaryWrite(cpj.GetContent());
        System.Web.HttpContext.Current.Response.End();

    }

}
