using FacturasAPI.Models.DTOs.Request;
using FacturasAPI.Models.DTOs.Response;
using FacturasAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FacturasAPI.Services.FacturaService
{
    public class FacturaService : IFacturaService
    {
        // Objeto de contexto de BBDD
        private readonly ApplicationDbContext context;

        public FacturaService(ApplicationDbContext applicationDbContext)
        {
            // Inyección de dependencia del DB Context
            context = applicationDbContext;
        }

		/*BaseResponse IFacturaService.CrearFactura(FacturaDTO facturaDTO)
		{
			BaseResponse response;

			using (context)
			{
				using (var transaction = context.Database.BeginTransaction())
				{
					try
					{
						Factura factura = new Factura();
						factura.Correlativo = facturaDTO.Correlativo;
						factura.Tipo = facturaDTO.Tipo;
						factura.Monto = facturaDTO.Monto;
						factura.Items = facturaDTO.Items;

						context.Add(factura);
						context.SaveChanges();

						response = new BaseResponse
						{
							status_code = StatusCodes.Status200OK,
							status_message = "Creado con éxito",
							data = new { message = "Factura agregada con éxito" }
						};

						transaction.Commit();

						return response;
					}
					catch (Exception ex)
					{
						response = new BaseResponse
						{
							status_code = StatusCodes.Status500InternalServerError,
							data = new { message = "Internal server error : " + ex.Message }
						};

						transaction.Rollback();

						return response;
					}
				}
			}
		}*/

		async Task<IActionResult> IFacturaService.CrearFactura(FacturaDTO facturaDTO)
		{
			BaseResponse response;

			using (context)
			{
				//using (var transaction = context.Database.BeginTransaction())
				using (var transaction = await context.Database.BeginTransactionAsync())
				{
					try
					{
						Factura factura = new Factura();
						factura.Correlativo = facturaDTO.Correlativo;
						factura.Tipo = facturaDTO.Tipo;
						factura.Monto = facturaDTO.Monto;
						factura.Items = facturaDTO.Items;

						context.Add(factura);
						//context.SaveChanges();
						await context.SaveChangesAsync();

						response = new BaseResponse
						{
							status_code = StatusCodes.Status200OK,
							status_message = "Creado con éxito",
							data = new { message = "Factura agregada con éxito" }
						};

						/*transaction.Commit();

						return response;*/
						await transaction.CommitAsync();

						return new ObjectResult(response)
						{
							StatusCode = StatusCodes.Status200OK
						};
					}
					catch (Exception ex)
					{
						response = new BaseResponse
						{
							status_code = StatusCodes.Status500InternalServerError,
							data = new { message = "Internal server error : " + ex.Message }
						};

						/*transaction.Rollback();

						return response;*/
						await transaction.RollbackAsync();

						return new ObjectResult(response)
						{
							StatusCode = StatusCodes.Status500InternalServerError
						};
					}
				}
			}
		}

		BaseResponse IFacturaService.ListarFacturas()
		{
			BaseResponse response;

			try {
				List<Factura> facturas = new List<Factura>();

				using (context) {
					context.Facturas.ToList().ForEach(factura => {
						facturas.Add(new Factura{
								Id = factura.Id,
								Correlativo = factura.Correlativo,
								Tipo = factura.Tipo,
								Monto = factura.Monto,
							});
						}
					);
				}

				response = new BaseResponse
				{
					status_code = StatusCodes.Status200OK,
					status_message = "Lista las facturas con éxito",
					data = new { facturas }
				};

				return response;
			}
			catch (Exception ex) {
				response = new BaseResponse
				{
					status_code = StatusCodes.Status500InternalServerError,
					data = new { message = "Error interno: " + ex.Message }
				};

				return response;
			}
		}
	}
}
