using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entities;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Data.Context;
using SolutionsTech.MVC.Dtos;

namespace SolutionsTech.MVC.Controllers
{
    public class InvoicingController : Controller
    {
        private readonly IInvoicingService _invoicingService;
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public InvoicingController(IInvoicingService invoicingService, ApplicationDbContext context, IMapper mapper)
        {
			_invoicingService = invoicingService;
			_context = context;
			_mapper = mapper;
		}

        // GET: Invoicing
        public async Task<IActionResult> Index()
        {
            var listInvoicing = await _invoicingService.GetListIndex();
			return View(_mapper.Map<List<InvoicingDto>>(listInvoicing));
		}

        // GET: Invoicing/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoicing = await _context.Invoicing
                .FirstOrDefaultAsync(m => m.IdInvoicing == id);
            if (invoicing == null)
            {
                return NotFound();
            }

            return View(invoicing);
        }

        // GET: Invoicing/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Invoicing/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInvoicing,TotalValue,Desconto,ValorFinal,DataFaturamento,Observation")] Invoicing invoicing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoicing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invoicing);
        }

        // GET: Invoicing/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoicing = await _context.Invoicing.FindAsync(id);
            if (invoicing == null)
            {
                return NotFound();
            }
            return View(invoicing);
        }

        // POST: Invoicing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInvoicing,TotalValue,Desconto,ValorFinal,DataFaturamento,Observation")] Invoicing invoicing)
        {
            if (id != invoicing.IdInvoicing)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoicing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoicingExists(invoicing.IdInvoicing))
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
            return View(invoicing);
        }

        // GET: Invoicing/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoicing = await _context.Invoicing
                .FirstOrDefaultAsync(m => m.IdInvoicing == id);
            if (invoicing == null)
            {
                return NotFound();
            }

            return View(invoicing);
        }

        // POST: Invoicing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoicing = await _context.Invoicing.FindAsync(id);
            if (invoicing != null)
            {
                _context.Invoicing.Remove(invoicing);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoicingExists(int id)
        {
            return _context.Invoicing.Any(e => e.IdInvoicing == id);
        }
    }
}
