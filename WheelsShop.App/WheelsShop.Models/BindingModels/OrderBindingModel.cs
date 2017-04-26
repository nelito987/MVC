using System;
using System.ComponentModel.DataAnnotations;
using WheelsShop.Models.EntityModels.Enums;
using WheelsShop.Models.ViewModels;

namespace WheelsShop.Models.BindingModels
{
    public class OrderBindingModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
