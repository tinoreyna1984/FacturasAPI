using FacturasAPI.Models.DTOs.Request;
using FacturasAPI.Models.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace FacturasAPI.Services.FacturaService
{
    public interface IFacturaService
    {
		//BaseResponse CrearFactura(FacturaDTO facturaDTO);
		Task<IActionResult> CrearFactura(FacturaDTO facturaDTO);
        BaseResponse ListarFacturas();
    }
}
