using Ecommerce.Data;
using Ecommerce.Data.Services;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;

        public ProductsController(IProductsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {

            var AllProducts = await _service.GetAllAsync(n => n.Company);
            return View(AllProducts);
        }
        //search
        public async Task<IActionResult> Filter(string searchString)
        {

            var allProducts = await _service.GetAllAsync(n => n.Company);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allProducts.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                //var filteredResultNew = allProducts.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResult);
            }
            return View("Index", allProducts);

        }


        //get: products/details/1
        public async Task<IActionResult>Details(int id)
        {
            var productDetails = await _service.GetProductByIDAsync(id);
            return View(productDetails);
        }

        //get: products/Create
        public async Task<IActionResult> Create()
        {
            var ProductDropdownData = await _service.GetNewProductsDropDownValues();
            ViewBag.Companies = new SelectList(ProductDropdownData.Companies, "Id", "Name");
            ViewBag.Brands = new SelectList(ProductDropdownData.Brands, "Id", "FullName");
            ViewBag.Suppliers = new SelectList(ProductDropdownData.Suppliers, "Id", "FullName");


            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(NewProductVm product)
        {
            if (!ModelState.IsValid)
            {
                var ProductDropdownData = await _service.GetNewProductsDropDownValues();
                ViewBag.Companies = new SelectList(ProductDropdownData.Companies, "Id", "Name");
                ViewBag.Brands = new SelectList(ProductDropdownData.Brands, "Id", "FullName");
                ViewBag.Suppliers = new SelectList(ProductDropdownData.Suppliers, "Id", "FullName");
                return View(product);
            }
            await _service.AddNewProductAsync(product);
            return RedirectToAction(nameof(Index));
        }

        //get: products/Edit/1
        public async Task<IActionResult> Edit(int id)
        {

            var ProductDetails = await _service.GetProductByIDAsync(id);
            if (ProductDetails == null) return View("NotFound");
            var response = new NewProductVm()
            {
                Id = ProductDetails.Id,
                Name = ProductDetails.Name,
                Description = ProductDetails.Description,
                Price = ProductDetails.Price,
                ManufactureDate = ProductDetails.ManufactureDate,
                ExpiredDate = ProductDetails.ExpiredDate,
                ImageUrl = ProductDetails.ImageUrl,
                ProductCategory = ProductDetails.ProductCategory,
                CompanyId = ProductDetails.CompanyId,
                BrandId = ProductDetails.BrandId,
                SupplierIds = ProductDetails.Supplier_Products.Select(n => n.SupplierId).ToList(),
            };


            var ProductDropdownData = await _service.GetNewProductsDropDownValues();
            ViewBag.Companies = new SelectList(ProductDropdownData.Companies, "Id", "Name");
            ViewBag.Brands = new SelectList(ProductDropdownData.Brands, "Id", "FullName");
            ViewBag.Suppliers = new SelectList(ProductDropdownData.Suppliers, "Id", "FullName");


            return View(response);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,NewProductVm product)
        {
            if (id != product.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var ProductDropdownData = await _service.GetNewProductsDropDownValues();
                ViewBag.Companies = new SelectList(ProductDropdownData.Companies, "Id", "Name");
                ViewBag.Brands = new SelectList(ProductDropdownData.Brands, "Id", "FullName");
                ViewBag.Suppliers = new SelectList(ProductDropdownData.Suppliers, "Id", "FullName");
                return View(product);
            }
            await _service.UpdateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }

    }
}
