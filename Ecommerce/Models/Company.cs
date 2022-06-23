using Ecommerce.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Company : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Logo is Requred")]
        [Display(Name = "Company Logo")]
        public string Logo { get; set; }

        [Required(ErrorMessage = "Name is Requred")]
        [Display(Name = "Company Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is Requred")]
        [Display(Name = "Company Description")]

        public string Description { get; set; }

        //Relationship
        public List<Product> Products { get; set; }
    }
}
