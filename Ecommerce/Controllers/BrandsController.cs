using Ecommerce.Data;
using Ecommerce.Data.Services;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class BrandsController : Controller
    {

        private readonly IBrandsService _service;

        public BrandsController(IBrandsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {

            var AllBrands = await _service.GetAllAsync();
            return View(AllBrands);
        }

        //get:Brands/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var BrandDetails = await _service.GetByIDAsync(id);
            if (BrandDetails == null) return View("NotFound");
            return View(BrandDetails);
        }
        //Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create ([Bind("ProfilePictureUrl,FullName,Bio")]Brand brand)
        {
            if (!ModelState.IsValid) return View(brand);
            await _service.AddAsync(brand);
            return RedirectToAction(nameof(Index));
        }

        //brands/edit/1
        public async Task<IActionResult> Edit (int id)
        {
            var BrandDetails =await _service.GetByIDAsync(id);
            if (BrandDetails == null) return View("NotFound");
            return View(BrandDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id ,[Bind("Id,ProfilePictureUrl,FullName,Bio")] Brand brand)
        {
            if (!ModelState.IsValid) return View(brand);
            if (id == brand.Id)
            {
                await _service.UpdateAsync(id, brand);
                return RedirectToAction(nameof(Index));

            }
            return View (brand);
            
        }

        //brands/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var BrandDetails = await _service.GetByIDAsync(id);
            if (BrandDetails == null) return View("NotFound");
            return View(BrandDetails);
        }

        [HttpPost , ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var BrandDetails = await _service.GetByIDAsync(id);
            if (BrandDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }



    }
}
