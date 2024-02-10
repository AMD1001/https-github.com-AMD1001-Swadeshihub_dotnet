using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaleCRMApp.Data;
using SaleCRMApp.Models;

namespace SaleCRMApp.Controllers
{
 
    public class LeadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Sales,Admin")]
        // GET: Leads
        public async Task<IActionResult> Index()
        {
              return _context.SalesLead != null ? 
                          View(await _context.SalesLead.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.SalesLead'  is null.");
        }
        [Authorize(Roles = "Sales,Admin")]
        // GET: Leads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SalesLead == null)
            {
                return NotFound();
            }

            var salesLeadEntity = await _context.SalesLead
                .FirstOrDefaultAsync(m => m.id == id);
            if (salesLeadEntity == null)
            {
                return NotFound();
            }

            return View(salesLeadEntity);
        }
        [Authorize(Roles = "Sales,Admin")]
        // GET: Leads/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Sales,Admin")]
        // POST: Leads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,FirstName,LastName,Mobile,Email,Source")] SalesLeadEntity salesLeadEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesLeadEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesLeadEntity);
        }
        [Authorize(Roles = "Sales")]
        // GET: Leads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SalesLead == null)
            {
                return NotFound();
            }

            var salesLeadEntity = await _context.SalesLead.FindAsync(id);
            if (salesLeadEntity == null)
            {
                return NotFound();
            }
            return View(salesLeadEntity);
        }
        [Authorize(Roles = "Sales")]
        // POST: Leads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,FirstName,LastName,Mobile,Email,Source")] SalesLeadEntity salesLeadEntity)
        {
            if (id != salesLeadEntity.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesLeadEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesLeadEntityExists(salesLeadEntity.id))
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
            return View(salesLeadEntity);
        }
        [Authorize(Roles = "Admin")]
        // GET: Leads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SalesLead == null)
            {
                return NotFound();
            }

            var salesLeadEntity = await _context.SalesLead
                .FirstOrDefaultAsync(m => m.id == id);
            if (salesLeadEntity == null)
            {
                return NotFound();
            }

            return View(salesLeadEntity);
        }
        [Authorize(Roles = "Admin")]
        // POST: Leads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SalesLead == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SalesLead'  is null.");
            }
            var salesLeadEntity = await _context.SalesLead.FindAsync(id);
            if (salesLeadEntity != null)
            {
                _context.SalesLead.Remove(salesLeadEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesLeadEntityExists(int id)
        {
          return (_context.SalesLead?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
