using System;
using System.ComponentModel.DataAnnotations;
using WheelsShop.Models.EntityModels;
using WheelsShop.Models.EntityModels.Enums;

namespace WheelsShop.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        
        [Required]
        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive number")]
        public int Quantity { get; set; }
        
        public User User { get; set; }
        public Status Status { get; set; }

        [DisplayFormat(DataFormatString = "{0: MM/dd/yyyy}")]
        public DateTime OrderDate { get; set; }
    }
}
