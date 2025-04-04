using Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO.Response.ProductCategory;
using System.Text.Json.Serialization;

namespace Application.DTO.Response.Product
{
    public class ProductResponseAll
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        public Status Status { get; set; }

        public DateTime DateCreated { set; get; }
        public ProductCategoryResponse ProductCategory { set; get; }


    }
}
