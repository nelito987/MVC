using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WheelsShop.Models.EntityModels.Enums;

namespace WheelsShop.Models.EntityModels
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required]
        public virtual Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public virtual User User { get; set; }

        [Required]
        public Status Status { get; set; }

        [DisplayFormat(DataFormatString = "{0: MM/dd/yyyy}")]
        public DateTime OrderDate { get; set; }
    }
}
