using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FacturasAPI.Models.Entities
{
    [Table("items")]
	public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string? Correlativo { get; set; }
        [Required]
        public decimal? Monto { get; set; }
    }
}
