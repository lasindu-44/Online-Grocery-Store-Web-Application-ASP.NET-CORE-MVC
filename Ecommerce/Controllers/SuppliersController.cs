using Ecommerce.Data;
using Ecommerce.Data.Services;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class SuppliersController : Controller
    {

        private readonly ISuppliersService _service;

        public SuppliersController(ISuppliersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data =await _service.GetAllAsync();
            return View(data);
        }


        //get: suppliers/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")]Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return View(supplier);
            }
            await _service.AddAsync(supplier);
            return RedirectToAction(nameof(Index));
        }

        //get :Supplier/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var supplierDetails =await _service.GetByIDAsync(id);
            if (supplierDetails == null) return View("NotFound");
            return View(supplierDetails);
            

        }

        //get: suppliers/Edit/1
        
        public async Task<IActionResult> Edit(int id)
        {
            var supplierDetails = await _service.GetByIDAsync(id);
            if (supplierDetails == null) return View("NotFound");
            return View(supplierDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id ,[Bind("Id,FullName,ProfilePictureUrl,Bio")] Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return View(supplier);
            }
            await _service.UpdateAsync(id,supplier);
            return RedirectToAction(nameof(Index));
        }

        //get: suppliers/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var supplierDetails = await _service.GetByIDAsync(id);
            if (supplierDetails == null) return View("NotFound");
            return View(supplierDetails);
        }

        [HttpPost,ActionName("Delete") ]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var supplierDetails = await _service.GetByIDAsync(id);
            if (supplierDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            
            return RedirectToAction(nameof(Index));
        }
    }
}
