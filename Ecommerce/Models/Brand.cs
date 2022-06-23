using Ecommerce.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Brand : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display (Name ="Logo")]
        [Required(ErrorMessage = "Profile Picture is Requred")]
        public string ProfilePictureUrl { get; set; }



        [Display(Name = "Brand Name")]
        [Required(ErrorMessage = "Full Name is Requred")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Full Name Must be between 2 and 50 chars")]
        public string FullName { get; set; }




        [Display(Name = "Description")]
        [Required(ErrorMessage = "Biography is Requred")]
        public string Bio { get; set; }

        //Relationship
        public List<Product> Products { get; set; }
    }
}
