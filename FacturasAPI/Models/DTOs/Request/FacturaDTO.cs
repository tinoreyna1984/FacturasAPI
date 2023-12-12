using FacturasAPI.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace FacturasAPI.Models.DTOs.Request
{
    public class FacturaDTO
    {
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
