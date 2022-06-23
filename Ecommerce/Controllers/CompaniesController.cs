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
    public class CompaniesController : Controller
    {
        private readonly ICompaniesService _service;

        public CompaniesController(ICompaniesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {

            var AllCompanies = await _service.GetAllAsync();
            return View(AllCompanies);
        }

        //Get: companies/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult>Create([Bind("Logo,Name,Description")]Company company)
        {
            if (!ModelState.IsValid) return View(company);
            await _service.AddAsync(company);
            return RedirectToAction(nameof(Index));
        }
        
        //get: Companies/Details/1
        public async Task<IActionResult>Details(int id)
        {
            var ComapanyDetails =await _service.GetByIDAsync(id);
            if (ComapanyDetails == null) return View("NotFound");
            return View(ComapanyDetails);
        }

        //get: Companies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var ComapanyDetails = await _service.GetByIDAsync(id);
            if (ComapanyDetails == null) return View("NotFound");
            return View(ComapanyDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,Logo,Name,Description")] Company company)
        {
            if (!ModelState.IsValid) return View(company);
            await _service.UpdateAsync(id,company);
            return RedirectToAction(nameof(Index));
        }

        //get: Companies/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var ComapanyDetails = await _service.GetByIDAsync(id);
            if (ComapanyDetails == null) return View("NotFound");
            return View(ComapanyDetails);
        }
        [HttpPost , ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var ComapanyDetails = await _service.GetByIDAsync(id);
            if (ComapanyDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }



    }
}
