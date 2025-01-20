using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using MyBack.Services;
using MyBack.Models;
using MyBack.Repositories;

namespace MyBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {

        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost]
        [Route("saveInvoice")]
        public IActionResult SaveInvoice([FromBody] InvoiceRequest invoiceRequest)
        {
            try
            {
                _invoiceService.SaveInvoice(invoiceRequest.Invoice, invoiceRequest.InvoiceDetails);
                return Ok(new { message = "Factura guardada correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al guardar la factura: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("searchInvoice")]
        public IActionResult SearchInvoice([FromBody] SearchInvoice searchParams)
        {
            List<InvoicesFound> facturas = _invoiceService.SearchInvoice(searchParams.Client, searchParams.NumeroFactura);

            return Ok(facturas);
        }
    }
}