using Ecommerce.Data.Base;
using Ecommerce.Data.ViewModels;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Data.Services
{
    public class ProductsService:EntityBaseRepository<Product>,IProductsService
    {

        private readonly AppDbContext _context; 
        public ProductsService(AppDbContext context) :base(context)
        {
            _context = context;
        }

        public async Task AddNewProductAsync(NewProductVm data)
        {
            var newProduct = new Product()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageUrl = data.ImageUrl,
                CompanyId = data.CompanyId,
                ManufactureDate = data.ManufactureDate,
                ExpiredDate = data.ExpiredDate,
                ProductCategory = data.ProductCategory,
                BrandId = data.BrandId

            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            //Add products suppliers
            foreach (var supplierId in data.SupplierIds)
            {

                var newSupplierProduct = new Supplier_Product()
                {
                    ProductId = newProduct.Id,
                    SupplierId = supplierId
            
                };
            await _context.Supplier_Products.AddAsync(newSupplierProduct);
                

            }
            await _context.SaveChangesAsync();

            
        }

        public async Task<NewProductsDropDownsVm> GetNewProductsDropDownValues()
        {
            var response = new NewProductsDropDownsVm()
            {
                Suppliers = await _context.Suppliers.OrderBy(n => n.FullName).ToListAsync(),
                Companies = await _context.Companies.OrderBy(n => n.Name).ToListAsync(),
                Brands = await _context.Brands.OrderBy(n => n.FullName).ToListAsync()

             };
            return response;
        }

        public async Task<Product> GetProductByIDAsync(int id)
        {
            var productDetails = await _context.Products
                .Include(C => C.Company)
            .Include(B => B.Brand)
            .Include(sp => sp.Supplier_Products).ThenInclude(s => s.Supplier)
            .FirstOrDefaultAsync(n => n.Id == id);

            return productDetails;
        }

        public async Task UpdateProductAsync(NewProductVm data)
        {

            var dbproduct = await _context.Products.FirstOrDefaultAsync(n => n.Id == data.Id);
            if (dbproduct != null)
            {

                dbproduct.Name = data.Name;
                dbproduct.Description = data.Description;
                dbproduct.Price = data.Price;
                dbproduct.ImageUrl = data.ImageUrl;
                dbproduct.CompanyId = data.CompanyId;
                dbproduct.ManufactureDate = data.ManufactureDate;
                dbproduct.ExpiredDate = data.ExpiredDate;
                dbproduct.ProductCategory = data.ProductCategory;
                dbproduct.BrandId = data.BrandId;

                
               
                await _context.SaveChangesAsync();
            }
            //Removove Existing suppliers
            var ExistingSupplierdb = _context.Supplier_Products.Where(n => n.ProductId == data.Id).ToList();
            _context.Supplier_Products.RemoveRange(ExistingSupplierdb);
            await _context.SaveChangesAsync();

            

            //Add products suppliers
            foreach (var supplierId in data.SupplierIds)
            {

                var newSupplierProduct = new Supplier_Product()
                {
                    ProductId = data.Id,
                    SupplierId = supplierId

                };
                await _context.Supplier_Products.AddAsync(newSupplierProduct);


            }
            await _context.SaveChangesAsync();
        }
    }
}
