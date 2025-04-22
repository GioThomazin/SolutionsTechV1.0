using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Data.Context;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Controllers
{
	public class TypeProcedureController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public TypeProcedureController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var typeProcedures = await _context.TypeProcedure.ToListAsync();
            var typeProcedureDto = _mapper.Map<List<TypeProcedure>>(typeProcedures);
            return View(typeProcedures);
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeProcedure = await _context.TypeProcedure
                .FirstOrDefaultAsync(m => m.IdTypeProcedure == id);
            if (typeProcedure == null)
            {
                return NotFound();
            }

            return View(typeProcedure);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TypeProcedure typeProcedure)
        {
            if (ModelState.IsValid)
            {
				_context.Add(typeProcedure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeProcedure);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeProcedure = await _context.TypeProcedure.FindAsync(id);
            if (typeProcedure == null)
            {
                return NotFound();
            }
            return View(typeProcedure);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdTypeProcedure,Name,Value,Duration")] TypeProcedure typeProcedure)
        {
            if (id != typeProcedure.IdTypeProcedure)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeProcedure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeProcedureExists(typeProcedure.IdTypeProcedure))
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
            return View(typeProcedure);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeProcedure = await _context.TypeProcedure
                .FirstOrDefaultAsync(m => m.IdTypeProcedure == id);
            if (typeProcedure == null)
            {
                return NotFound();
            }

            return View(typeProcedure);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (id == 0)
            {
                return NotFound();

            }
            var typeProcedure = await _context.TypeProcedure.FindAsync(id);
            if (typeProcedure == null)
            {
                return NotFound();
            }
            _context.TypeProcedure.Remove(typeProcedure);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeProcedureExists(long id)
        {
            return _context.TypeProcedure.Any(e => e.IdTypeProcedure == id);
        }
    }
}
