using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Data.Context;

namespace SolutionsTech.MVC.Controllers
{
	public class FormPaymentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FormPaymentController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var formPayments = await _context.FormPayment.ToListAsync();
            var formPaymentDto = _mapper.Map<List<FormPayment>>(formPayments);
            return View(formPaymentDto);
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formPayment = await _context.FormPayment
                .FirstOrDefaultAsync(m => m.IdFormPayment == id);
            if (formPayment == null)
            {
                return NotFound();
            }

            return View(formPayment);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFormPayment,Name,DtCreate,Active")] FormPayment formPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formPayment);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formPayment = await _context.FormPayment.FindAsync(id);
            if (formPayment == null)
            {
                return NotFound();
            }
            return View(formPayment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdFormPayment,Name,DtCreate,Active")] FormPayment formPayment)
        {
            if (id != formPayment.IdFormPayment)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormPaymentExists(formPayment.IdFormPayment))
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
            return View(formPayment);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formPayment = await _context.FormPayment
                .FirstOrDefaultAsync(m => m.IdFormPayment == id);
            if (formPayment == null)
            {
                return NotFound();
            }

            return View(formPayment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var formPayment = await _context.FormPayment.FindAsync(id);
            if (formPayment == null)
            {
                return NotFound();
            }

            _context.FormPayment.Remove(formPayment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormPaymentExists(long id)
        {
            return _context.FormPayment.Any(e => e.IdFormPayment == id);
        }
    }
}
