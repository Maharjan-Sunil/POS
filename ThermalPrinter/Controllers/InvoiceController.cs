using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ThermalPrinter.Models;
using ThermalPrinter.Models.DataManager;

namespace ThermalPrinter.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly InvoiceDataManager _invoiceDataManager;

        public InvoiceController()
        {
            _invoiceDataManager = new InvoiceDataManager();
        }
        // GET: Invoice
        public List<InvoiceModel> GetInvoiceByOrderId(int orderId)
        {
            var list = new List<InvoiceModel>();
            try
            {
                list = _invoiceDataManager.GetInvoiceByOrderId(orderId);
            }
            catch(Exception ex)
            {

            }
            return list;
        }
    }
}