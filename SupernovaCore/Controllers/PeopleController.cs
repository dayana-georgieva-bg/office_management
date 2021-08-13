using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SupernovaCore.Models;
using SupernovaCore.Services;
using SupernovaCore.ViewModel;

namespace SupernovaCore.Controllers
{
    public class PeopleController : Controller
    {
        private readonly Supernova_teamContext _context;
        private readonly IEmployeesService employeesService;

        public PeopleController(Supernova_teamContext context, IEmployeesService employeesService)
        {
            _context = context;
            this.employeesService = employeesService;
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            try
            {
                var employeesWithResources = await this.employeesService.GetEmployeesWithResources();
                return View(employeesWithResources);
            }
            catch (Exception ex)
            {
                // Log error/ex
                throw ;
            }
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeInformation = await this.employeesService.EmployeeDetails(id);

            if (employeeInformation == null)
            {
                return NotFound();
            }

            return View(employeeInformation);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            ViewData["CompanyResourcesId"] = new SelectList(_context.CompanyResources, "Id", "Id");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupernovaModel supernovaCreate)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            var create = await this.employeesService.EmployeeCreate(supernovaCreate);
           
            return RedirectToAction(nameof(Index));
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var employeesInformation = await _context.EmployeesInformations
            //    .Include(e => e.CompanyResources)
            //    .Where(r => r.Id == id && r.CompanyResourcesId == r.CompanyResources.Id)
            //    .FirstOrDefaultAsync();
            var employeesInformation = await this.employeesService.EmployeeEditGet(id);

            if (employeesInformation == null)
            {
                return NotFound();
            }

            return View(employeesInformation);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SupernovaModel employeesInformation, int id)
        {

            var edit = await this.employeesService.EmployeeEditPost(employeesInformation, id);

            if (id != employeesInformation.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeesInformationExists(employeesInformation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return View(employeesInformation);

            }
            return RedirectToAction(nameof(Index));

        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeesInformation = await _context.EmployeesInformations
                .Include(e => e.CompanyResources)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeesInformation == null)
            {
                return NotFound();
            }

            return View(employeesInformation);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var employeesInformation = await _context.EmployeesInformations
                .Include(r => r.CompanyResources)
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            _context.EmployeesInformations.Remove(employeesInformation);
             await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool EmployeesInformationExists(int id)
        {
            return _context.EmployeesInformations.Any(e => e.Id == id);
        }
    }
}
