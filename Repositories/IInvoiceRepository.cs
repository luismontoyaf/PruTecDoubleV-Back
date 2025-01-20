using MyBack.Models;
using System.Collections.Generic;

namespace MyBack.Repositories
{
    public interface IInvoiceRepository
    {
        public void SaveInvoice(Invoice invoice, List<InvoiceDetail> invoiceDetails);

        public List<InvoicesFound> SearchInvoice(string? razonSocial, string? numeroFactura);
    }
}
