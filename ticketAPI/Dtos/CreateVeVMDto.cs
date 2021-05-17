using System.ComponentModel.DataAnnotations;

namespace ticketAPI.Dtos
{
    public record CreateVeVMDto
    {
        [Required]
        public int maGhe { get; set; }

        [Required]
        [Range(1, 200000)]
        public double giaVe { get; set; }
    }
}