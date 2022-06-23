using Ecommerce.Data.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Data.ViewModels
{
    public class ShoppingCartVM
    {
        public ShoppingCart shoppingCart { get; set; }

        public double shoppingCartTotal { get; set; }
    }
}
