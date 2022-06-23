using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class OrderItem
    {
        [Key]


        public int Id { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]

        public Product Product { get; set; }

        public int OrdersId { get; set; }
        [ForeignKey("OrdersId")]

        public Orders Orders { get; set; }
    }
}
