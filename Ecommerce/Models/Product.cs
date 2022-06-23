using Ecommerce.Data;
using Ecommerce.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Product : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        [Display(Name="Image")]
        public string ImageUrl { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public ProductCategory ProductCategory { get; set; }

        //Relationships

        public List<Supplier_Product> Supplier_Products { get; set; }

        //Company
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        //Brand
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

    }
}
