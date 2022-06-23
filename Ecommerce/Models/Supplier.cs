using Ecommerce.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Supplier : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo")]
        [Required(ErrorMessage ="Profile Picture is Requred")]
        
        public string ProfilePictureUrl { get; set; }




        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is Requred")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name Must be between 3 and 50 chars")]
        public string FullName { get; set; }



        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is Requred")]
        public string Bio { get; set; }

        //Relationships
        public List<Supplier_Product> Supplier_Products { get; set; }

    }
}
