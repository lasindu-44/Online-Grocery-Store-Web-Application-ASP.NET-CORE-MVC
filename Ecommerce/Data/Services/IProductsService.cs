using Ecommerce.Data.Base;
using Ecommerce.Data.ViewModels;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Data.Services
{
    public interface IProductsService:IEntityBaseRepository<Product>
    {
        Task<Product> GetProductByIDAsync(int id);
        Task<NewProductsDropDownsVm> GetNewProductsDropDownValues();

        Task AddNewProductAsync(NewProductVm data);

        Task UpdateProductAsync(NewProductVm data);
    }
}
