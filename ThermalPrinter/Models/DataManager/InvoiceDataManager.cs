using System;
using System.Collections.Generic;

namespace ThermalPrinter.Models.DataManager
{
    public class InvoiceDataManager
    {
        public List<InvoiceModel> GetInvoiceByOrderId(int order)
        {
            var InvoiceList = new List<InvoiceModel>();
            try
            {
                var invoice = new InvoiceModel
                {
                    Items = "Momo",
                    Quantity = 2,
                    Rate = 100,
                    Total = 2 * 100
                };

                var invoice1 = new InvoiceModel
                {
                    Items = "Momo Veg",
                    Quantity = 2,
                    Rate = 100,
                    Total = 2 * 100
                };
                InvoiceList.Add(invoice);
                //InvoiceList.Add(invoice1);
            }
            catch (Exception ex)
            {

            }
            return InvoiceList;
        }
    }
}