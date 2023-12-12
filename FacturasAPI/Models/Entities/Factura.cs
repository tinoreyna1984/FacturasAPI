using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturasAPI.Models.Entities
{
    [Table("facturas")]
    public class Factura
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string? Correlativo { get; set; }
        [Required]
        public string? Tipo { get; set; }
        [Required]
        public decimal? Monto { get; set; }
        [Required]
        public List<Item>? Items { get; set; }
    }
}
