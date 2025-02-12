using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Data.Context;

namespace SolutionsTech.MVC.Controllers
{
	public class SchedulingProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SchedulingProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SchedulingProduct
        public async Task<IActionResult> Index()
        {
            return View(await _context.SchedulingProduct.ToListAsync());
        }

        // GET: SchedulingProduct/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedulingProduct = await _context.SchedulingProduct
                .FirstOrDefaultAsync(m => m.IdSchedulingProduct == id);
            if (schedulingProduct == null)
            {
                return NotFound();
            }

            return View(schedulingProduct);
        }

        // GET: SchedulingProduct/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SchedulingProduct/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSchedulingProduct")] SchedulingProduct schedulingProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedulingProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schedulingProduct);
        }

        // GET: SchedulingProduct/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedulingProduct = await _context.SchedulingProduct.FindAsync(id);
            if (schedulingProduct == null)
            {
                return NotFound();
            }
            return View(schedulingProduct);
        }

        // POST: SchedulingProduct/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdSchedulingProduct")] SchedulingProduct schedulingProduct)
        {
            if (id != schedulingProduct.IdSchedulingProduct)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedulingProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchedulingProductExists(schedulingProduct.IdSchedulingProduct))
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
            return View(schedulingProduct);
        }

        // GET: SchedulingProduct/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedulingProduct = await _context.SchedulingProduct
                .FirstOrDefaultAsync(m => m.IdSchedulingProduct == id);
            if (schedulingProduct == null)
            {
                return NotFound();
            }

            return View(schedulingProduct);
        }

        // POST: SchedulingProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var schedulingProduct = await _context.SchedulingProduct.FindAsync(id);
            if (schedulingProduct != null)
            {
                _context.SchedulingProduct.Remove(schedulingProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchedulingProductExists(long id)
        {
            return _context.SchedulingProduct.Any(e => e.IdSchedulingProduct == id);
        }
    }
}
