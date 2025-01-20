using MyBack.Repositories;
using MyBack.Models;
using System.Collections.Generic;

namespace MyBack.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public void SaveInvoice(Invoice invoice, List<InvoiceDetail> invoiceDetail)
        {
            _invoiceRepository.SaveInvoice(invoice, invoiceDetail);
        }

        public List<InvoicesFound> SearchInvoice(string? razonSocial, string? numeroFactura){
            return _invoiceRepository.SearchInvoice(razonSocial, numeroFactura);
        }
    }
}
