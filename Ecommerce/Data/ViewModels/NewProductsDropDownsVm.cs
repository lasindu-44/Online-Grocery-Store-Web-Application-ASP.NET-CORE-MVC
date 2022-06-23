using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Data.ViewModels
{
    public class NewProductsDropDownsVm
    {

        public NewProductsDropDownsVm()
        {
            Brands = new List<Brand>();
            Companies = new List<Company>();
            Suppliers = new List<Supplier>();
        }
        public List<Brand> Brands { get; set; }
        public List<Company> Companies { get; set; }
        public List<Supplier> Suppliers { get; set; }
    }
}
