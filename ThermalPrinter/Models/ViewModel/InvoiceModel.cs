namespace ThermalPrinter.Models
{
    public class InvoiceModel
    {
        public string Items { get; set; }
        public int Quantity { get; set; }
        public int Rate { get; set; }
        public decimal Total { get; set; }
    }
}