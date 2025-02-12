using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Data.Context;

namespace SolutionsTech.MVC.Controllers
{
	public class SchedulingProcedureController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SchedulingProcedureController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SchedulingProcedure
        public async Task<IActionResult> Index()
        {
            return View(await _context.SchedulingProcedure.ToListAsync());
        }

        // GET: SchedulingProcedure/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedulingProcedure = await _context.SchedulingProcedure
                .FirstOrDefaultAsync(m => m.IdSchedulingProcedure == id);
            if (schedulingProcedure == null)
            {
                return NotFound();
            }

            return View(schedulingProcedure);
        }

        // GET: SchedulingProcedure/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SchedulingProcedure/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSchedulingProcedure")] SchedulingProcedure schedulingProcedure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedulingProcedure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schedulingProcedure);
        }

        // GET: SchedulingProcedure/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedulingProcedure = await _context.SchedulingProcedure.FindAsync(id);
            if (schedulingProcedure == null)
            {
                return NotFound();
            }
            return View(schedulingProcedure);
        }

        // POST: SchedulingProcedure/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdSchedulingProcedure")] SchedulingProcedure schedulingProcedure)
        {
            if (id != schedulingProcedure.IdSchedulingProcedure)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedulingProcedure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchedulingProcedureExists(schedulingProcedure.IdSchedulingProcedure))
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
            return View(schedulingProcedure);
        }

        // GET: SchedulingProcedure/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedulingProcedure = await _context.SchedulingProcedure
                .FirstOrDefaultAsync(m => m.IdSchedulingProcedure == id);
            if (schedulingProcedure == null)
            {
                return NotFound();
            }

            return View(schedulingProcedure);
        }

        // POST: SchedulingProcedure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var schedulingProcedure = await _context.SchedulingProcedure.FindAsync(id);
            if (schedulingProcedure != null)
            {
                _context.SchedulingProcedure.Remove(schedulingProcedure);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchedulingProcedureExists(long id)
        {
            return _context.SchedulingProcedure.Any(e => e.IdSchedulingProcedure == id);
        }
    }
}
