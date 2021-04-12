using Neodynamic.SDK.Printing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using ThermalPrinter.Models;

public class GetWebPrintJobController : Controller
{

    [AllowAnonymous]
    public void Index(int? orderId = 0)
    {
        //Create a WebPrintJob obj 
        WebPrintJob webPj = new WebPrintJob();

        //Get Invoice Model as per order id and 
        //pass it To GenerateBasicThermalLabel(model);

        //set a ThermalLabel obj 
        webPj.ThermalLabel = GenerateBasicThermalLabel();

        //display print dialog to the client  
        webPj.ShowPrintDialog = false;

        //Serialize WebPrintJob and send it back to the client
        //so it can be processed by the TLClientPrint utility
        HttpContext.Response.ContentType = "text/plain";
        HttpContext.Response.Write(webPj.ToString());
        HttpContext.Response.Flush();
        HttpContext.Response.End();

    }

    private ThermalLabel GenerateBasicThermalLabel()
    {
        //Define a ThermalLabel object and set unit to inch and label size
        ThermalLabel tLabel = new ThermalLabel(Neodynamic.SDK.Printing.UnitType.Inch, 4, 6);
        tLabel.GapLength = 0.2;

        //Define a couple of TextItem objects for Employee info
        TextItem txt1 = new TextItem();
        //set data field
        txt1.DataField = "Items";
        //set font
        txt1.Font.Name = Font.NativePrinterFontA;
        txt1.Font.Unit = FontUnit.Point;
        txt1.Font.Size = 10;
        txt1.TextPadding = new FrameThickness(0.5);
    

        TextItem txt2 = new TextItem();
        //set data field
        txt2.DataField = "Quantity";
        //set font
        txt2.Font.Name = Font.NativePrinterFontA;
        txt2.Font.Unit = FontUnit.Point;
        txt2.Font.Size = 10;
        txt1.TextPadding = new FrameThickness(0.5);



        //TextItem txt3 = new TextItem();
        ////set data field
        //txt3.DataField = "Rate";
        ////set font
        //txt3.Font.Name = Font.NativePrinterFontA;
        //txt3.Font.Unit = FontUnit.Point;
        //txt3.Font.Size = 10;
      
        //TextItem txt4 = new TextItem(0.13, 0.05, 2.8, 0.3, "");
        ////set data field
        //txt4.DataField = "Total";
        ////set font
        //txt4.Font.Name = Font.NativePrinterFontA;
        //txt4.Font.Unit = FontUnit.Point;
        //txt4.Font.Size = 10;
    


        tLabel.Items.Add(txt1);
        tLabel.Items.Add(txt2);
        //tLabel.Items.Add(txt3);
        //tLabel.Items.Add(txt4);
        tLabel.DataSource = GetInvoiceByOrderId(1);


        //TextItem title = new TextItem(0.5, 0.5, 2.5, 0.5, "Ismartmandu");
        //title.TextPadding = new FrameThickness(0.2);
        //TextItem address = new TextItem(0.5, 0.5, 2.5, 0.5, "Kathmandu, Nepal");
        //address.TextPadding = new FrameThickness(0.2);

        //var orderlist = GetInvoiceByOrderId(1);

        //foreach(var order in orderlist)
        //{

        //}

        //TextItem Greetings = new TextItem(0.5, 0.5, 2.5, 0.5, "Thank you for vist");
        //Greetings.TextPadding = new FrameThickness(0.2);
        ////Add items to ThermalLabel object...
        //tLabel.Items.Add(title);
        //tLabel.Items.Add(address);
        //tLabel.Items.Add(Greetings);
        //tLabel.DataSource=orderlist;

        return tLabel;
    }


    private List<Invoice> GetInvoiceByOrderId(int order)
    {
        var InvoiceList = new List<Invoice>();
        try
        {
            var invoice = new Invoice
            {
                Items = "Momo",
                Quantity = 2,
                Rate = 100,
                Total = 2 * 100
            };

            var invoice1 = new Invoice
            {
                Items = "Momo Veg",
                Quantity = 2,
                Rate = 100,
                Total = 2 * 100
            };
            InvoiceList.Add(invoice);
            //InvoiceList.Add(invoice1);
        }
        catch(Exception ex)
        {

        }
        return InvoiceList;
    }
}
