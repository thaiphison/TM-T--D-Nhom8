using System.ComponentModel.DataAnnotations;

namespace ticketAPI.Dtos
{
    public record UpdateVeVMDto
    {
        [Required]
        [Range(1, 200000)]
        public double giaVe { get; set; }
    }
}