using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SupernovaCore.Models;
using SupernovaCore.ViewModel;

namespace SupernovaCore.Controllers
{
    public class PeopleController : Controller
    {
        private readonly Supernova_teamContext _context;

        public PeopleController(Supernova_teamContext context)
        {
            _context = context;
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            try
            {
                var supernova_teamContext = _context.EmployeesInformations.Include(e => e.CompanyResources);
                return View(await supernova_teamContext.ToListAsync());

               // return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
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

            SupernovaModel supernovaModel = new SupernovaModel()
            {
                Id = (int)id,
                FirstName = employeesInformation.FirstName,
                SecondName = employeesInformation.SecondName,
                LastName = employeesInformation.LastName,
                Address = employeesInformation.Address,
                MobileNumber = employeesInformation.MobileNumber,
                Email = employeesInformation.Email,
                Position = employeesInformation.Position,
                Birthday = employeesInformation.Birthday,
                CompanyResourcesId = (int)employeesInformation.CompanyResourcesId,
                LaptopModel = employeesInformation.CompanyResources.LaptopModel,
                MonitorModel = employeesInformation.CompanyResources.MonitorModel,
                LaptopSN = employeesInformation.CompanyResources.LaptopSN,
                MonitorSN = employeesInformation.CompanyResources.MonitorSN,
                MobilePhone = employeesInformation.CompanyResources.MobilePhone,
                CompanyMobileNumber = employeesInformation.CompanyResources.CompanyMobileNumber,
                Headphones = employeesInformation.CompanyResources.Headphones,
                OtherInfo = employeesInformation.CompanyResources.OtherInfo
            };

            return View(supernovaModel);
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

            CompanyResource companyResource = new CompanyResource()
            {
                Id = 0,
                LaptopModel = supernovaCreate.LaptopModel,
                MonitorModel = supernovaCreate.MonitorModel,
                LaptopSN = supernovaCreate.LaptopSN,
                MonitorSN = supernovaCreate.MonitorSN,
                MobilePhone = supernovaCreate.MobilePhone,
                CompanyMobileNumber = supernovaCreate.CompanyMobileNumber,
                Headphones = supernovaCreate.Headphones,
                OtherInfo = supernovaCreate.OtherInfo
            };
            try
            {
                _context.Add(companyResource);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return View(supernovaCreate);
            }

            EmployeesInformation employeesInformation = new EmployeesInformation()
            {
                Id = 0,
                FirstName = supernovaCreate.FirstName,
                SecondName = supernovaCreate.SecondName,
                LastName = supernovaCreate.LastName,
                Address = supernovaCreate.Address,
                MobileNumber = supernovaCreate.MobileNumber,
                Email = supernovaCreate.Email,
                Position = supernovaCreate.Position,
                Birthday = supernovaCreate.Birthday,
                CompanyResourcesId = companyResource.Id
            };
            try
            {
                _context.Add(employeesInformation);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return View(supernovaCreate);
            }
            //ViewData["CompanyResourcesId"] = new SelectList(_context.CompanyResources, "Id", "Id", employeesInformation.CompanyResourcesId);
            return RedirectToAction(nameof(Index));
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeesInformation = await _context.EmployeesInformations
                .Include(e => e.CompanyResources)
                .Where(r => r.Id == id && r.CompanyResourcesId == r.CompanyResources.Id)
                .FirstOrDefaultAsync();
            if (employeesInformation == null)
            {
                return NotFound();
            }

            SupernovaModel supernovaModel = new SupernovaModel()
            {
                Id = (int)id,
                FirstName = employeesInformation.FirstName,
                SecondName = employeesInformation.SecondName,
                LastName = employeesInformation.LastName,
                Address = employeesInformation.Address,
                MobileNumber = employeesInformation.MobileNumber,
                Email = employeesInformation.Email,
                Position = employeesInformation.Position,
                Birthday = employeesInformation.Birthday,
                CompanyResourcesId = (int)employeesInformation.CompanyResourcesId,
                LaptopModel = employeesInformation.CompanyResources.LaptopModel,
                MonitorModel = employeesInformation.CompanyResources.MonitorModel,
                LaptopSN = employeesInformation.CompanyResources.LaptopSN,
                MonitorSN = employeesInformation.CompanyResources.MonitorSN,
                MobilePhone = employeesInformation.CompanyResources.MobilePhone,
                CompanyMobileNumber = employeesInformation.CompanyResources.CompanyMobileNumber,
                Headphones = employeesInformation.CompanyResources.Headphones,
                OtherInfo = employeesInformation.CompanyResources.OtherInfo
            };
            //ViewData["CompanyResourcesId"] = new SelectList(_context.CompanyResources, "Id", "Id", employeesInformation.CompanyResourcesId);
            return View(supernovaModel);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SupernovaModel employeesInformation, int id)
        {
            //var teamContext = await _context.EmployeesInformations.FindAsync(employeesInformation.Id);
            var teamContext = await _context.EmployeesInformations
                .Include(e => e.CompanyResources)
                .Where(r => r.Id == id && r.CompanyResourcesId == r.CompanyResources.Id)
                .FirstOrDefaultAsync();

            if (id != employeesInformation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                teamContext.FirstName = employeesInformation.FirstName;
                teamContext.SecondName = employeesInformation.SecondName;
                teamContext.LastName = employeesInformation.LastName;
                teamContext.Position = employeesInformation.Position;
                teamContext.Email = employeesInformation.Email;
                teamContext.Birthday = employeesInformation.Birthday;
                teamContext.Address = employeesInformation.Address;
                teamContext.MobileNumber = employeesInformation.MobileNumber;

                teamContext.CompanyResources.CompanyMobileNumber = employeesInformation.CompanyMobileNumber;
                teamContext.CompanyResources.Headphones = employeesInformation.Headphones;
                teamContext.CompanyResources.LaptopModel = employeesInformation.LaptopModel;
                teamContext.CompanyResources.LaptopSN = employeesInformation.LaptopSN;
                teamContext.CompanyResources.MobilePhone = employeesInformation.MobilePhone;
                teamContext.CompanyResources.MonitorModel = employeesInformation.MonitorModel;
                teamContext.CompanyResources.MonitorSN = employeesInformation.MonitorSN;
                teamContext.CompanyResources.OtherInfo = employeesInformation.OtherInfo;
                try
                {
                    _context.Update(teamContext);
                    await _context.SaveChangesAsync();
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

                return RedirectToAction(nameof(Index));
            }
            //ViewData["CompanyResourcesId"] = new SelectList(_context.CompanyResources, "Id", "Id", employeesInformation.CompanyResourcesId);
            return View(employeesInformation);
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
            var employeesInformation = await _context.EmployeesInformations.FindAsync(id);
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
