using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleCRMApp.Data;
using SwadeshiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwadeshiApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create order
       
        public async Task<IActionResult> CreateOrder(OrderItem orderItem)
        {
            if (!ModelState.IsValid)
            {
                orderItem.Product = await _context.Product.FindAsync(orderItem.ProductId);
                
                _context.Add(orderItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderItem);
        }

        // Fetch orders by userId
        public async Task<IActionResult> OrdersByUserId(string userId)
        {
            var orders = await _context.OrderItem.Where(o => o.UserId == userId).ToListAsync();
            return View(orders);
        }

        // Edit order by orderId
        public async Task<IActionResult> Edit(int? orderId)
        {
            if (orderId == null)
            {
                return NotFound();
            }

            var orderItem = await _context.OrderItem.FindAsync(orderId);
            if (orderItem == null)
            {
                return NotFound();
            }
            return View(orderItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int orderId, OrderItem orderItem)
        {
            if (orderId != orderItem.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (orderItem.OrderId.HasValue && OrderItemExists(orderItem.OrderId.Value))
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
            return View(orderItem);
        }

        // Delete order by orderId
        public async Task<IActionResult> Delete(int? orderId)
        {
            if (orderId == null)
            {
                return NotFound();
            }

            var orderItem = await _context.OrderItem
                .FirstOrDefaultAsync(m => m.OrderId == orderId);
            if (orderItem == null)
            {
                return NotFound();
            }

            return View(orderItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int orderId)
        {
            var orderItem = await _context.OrderItem.FindAsync(orderId);
            _context.OrderItem.Remove(orderItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderItemExists(int id)
        {
            return _context.OrderItem.Any(e => e.OrderId == id);
        }
    }
}
