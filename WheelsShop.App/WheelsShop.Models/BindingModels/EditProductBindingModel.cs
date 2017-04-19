﻿using System.ComponentModel.DataAnnotations;
using System.Web;
using WheelsShop.Models.EntityModels.Enums;

namespace WheelsShop.Models.BindingModels
{
    public class EditProductBindingModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2} BGN")]
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Season Season { get; set; }

        public int Size { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public string PCD { get; set; }

        [Display(Name = "Image")]
        [DataType(DataType.ImageUrl)]
        public HttpPostedFileBase ImageUrl { get; set; }
    }
}
