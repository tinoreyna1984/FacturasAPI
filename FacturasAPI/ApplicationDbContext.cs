using FacturasAPI.Models;
using FacturasAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FacturasAPI
{
    public class ApplicationDbContext : DbContext
	{
		// constructor
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public virtual DbSet<Factura> Facturas { get; set; }
	}
}
