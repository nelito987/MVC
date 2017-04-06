using System.ComponentModel.DataAnnotations;
using WheelsShop.Models.EntityModels.Enums;

namespace WheelsShop.Models.EntityModels
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Status Status { get; set; }
    }
}
