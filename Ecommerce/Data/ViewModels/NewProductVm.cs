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
    public class NewProductVm
    {

        public int Id { get; set; }

        [Display(Name="Product Name")]
         [Required(ErrorMessage ="Product Name is Requred")]
        public string Name { get; set; }
        [Display(Name = "Product Description")]
        [Required(ErrorMessage = "Product Description is Requred")]
        public string Description { get; set; }

        [Display(Name = "Product Price")]
        [Required(ErrorMessage = "Product Price is Requred")]
        public double Price { get; set; }
        [Display(Name = "Product Image")]
        [Required(ErrorMessage = "Product Image is Requred")]
        public string ImageUrl { get; set; }
        [Display(Name = "Manufacture Date")]
        [Required(ErrorMessage = "Manufacture Date is Requred")]
        public DateTime ManufactureDate { get; set; }

        [Display(Name = "Expired Date")]
        [Required(ErrorMessage = "Expired Date is Requred")]
        public DateTime ExpiredDate { get; set; }

        [Display(Name = "Select Product Category")]
        [Required(ErrorMessage = "Product Category is Requred")]
        public ProductCategory ProductCategory { get; set; }

        //Relationships
        [Display(Name = "Select Sepplier(s)")]
        [Required(ErrorMessage = "Supplier is Requred")]
        public List<int> SupplierIds { get; set; }

        [Display(Name = "Select Company")]
        [Required(ErrorMessage = "Company is Requred")]
        public int CompanyId { get; set; }


        [Display(Name = "Select Brand")]
        [Required(ErrorMessage = "Brand Requred")]
        public int BrandId { get; set; }
        

    }
}
