using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="EmailAddress")]
        [Required(ErrorMessage ="Email is Required")]
        public string EmailAddress { get; set; }



        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
