using Ecommerce.Data.Base;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Data.Services
{
    public class SuppliersService : EntityBaseRepository<Supplier>, ISuppliersService
    {


        
        public SuppliersService(AppDbContext context) : base (context){ }
        
       
    }
}
