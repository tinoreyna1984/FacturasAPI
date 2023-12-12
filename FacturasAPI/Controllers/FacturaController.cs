using FacturasAPI.Models.DTOs.Request;
using FacturasAPI.Models.DTOs.Response;
using FacturasAPI.Services.FacturaService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FacturasAPI.Controllers
{
	[Route("api/rs/examen/[controller]")]
	[ApiController]
	public class FacturaController : ControllerBase
	{
		private readonly IFacturaService facturaService;

        public FacturaController(IFacturaService facturaService) // inyecta dependencia de servicio
        {
            this.facturaService = facturaService;
        }

		// endpoints
		[HttpPost("agregar")]
		public Task<IActionResult> CreaFactura(FacturaDTO facturaDTO) {
			return facturaService.CrearFactura(facturaDTO);
		}
		/*public BaseResponse CreaFactura(FacturaDTO facturaDTO) {
			return facturaService.CrearFactura(facturaDTO);
		}*/

		[HttpGet("listar")]
		public BaseResponse ListaFacturas() {
			return facturaService.ListarFacturas();
		}
    }
}
