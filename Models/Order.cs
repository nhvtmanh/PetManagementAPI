using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetManagementAPI.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public byte Status { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public string CustomerId { get; set; } = string.Empty;

        [ForeignKey("Payment")]
        public Guid? PaymentId { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public Payment? Payment { get; set; }
    }
}
