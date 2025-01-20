using MyBack.Models;
using System.Collections.Generic;

namespace MyBack.Services
{
    public interface IInvoiceService
    {
        public void SaveInvoice(Invoice invoice, List<InvoiceDetail> invoiceDetail);

        public List<InvoicesFound> SearchInvoice(string? razonSocial, string? numeroFactura);
    }
}
