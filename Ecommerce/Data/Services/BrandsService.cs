using Ecommerce.Data.Base;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Data.Services
{
    public class BrandsService : EntityBaseRepository<Brand>, IBrandsService
    {
        public BrandsService(AppDbContext context): base (context)
        {

        }
    }
}
