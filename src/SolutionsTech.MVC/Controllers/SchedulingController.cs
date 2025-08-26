using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Data.Context;
using SolutionsTech.MVC.Dto;
using SolutionsTech.MVC.Dtos.ViewModel;

namespace SolutionsTech.MVC.Controllers
{
    public class SchedulingController : Controller
    {
        private readonly ISchedulingService _schedulingService;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SchedulingController(ApplicationDbContext context, IMapper mapper, ISchedulingService schedulingService)
        {
            _context = context;
            _mapper = mapper;
            _schedulingService = schedulingService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _schedulingService.GetListIndex();
            return View(_mapper.Map<List<SchedulingDto>>(list));
        }

        // GET: Scheduling/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduling = await _context.Scheduling
                .Include(s => s.IdFormPayment)
                .Include(s => s.IdUser)
                .FirstOrDefaultAsync(m => m.IdScheduling == id);
            if (scheduling == null)
            {
                return NotFound();
            }

            return View(scheduling);
        }

        public async Task<IActionResult> Create()
        {
            var users = await _context.Users.ToListAsync();
            var formPayments = await _context.FormPayment.ToListAsync();
            var typeProcedures = await _context.TypeProcedure.ToListAsync();

            var viewModel = new SchedulingDto
            {
                Users = _mapper.Map<List<UserDto>>(users),
                FormPayments = _mapper.Map<List<FormPaymentDto>>(formPayments),
                TypeProcedures = _mapper.Map<List<TypeProcedureDto>>(typeProcedures) // Carregue os procedimentos
            };

            return View(viewModel); // Retorne a view com o viewModel
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SchedulingDto schedulingDto)
        {
            ModelState.Remove("Observation");

            if (!ModelState.IsValid)
            {
                var users = await _context.Users.ToListAsync();
                var formPayments = await _context.FormPayment.ToListAsync();
                var typeProcedures = await _context.TypeProcedure.ToListAsync();

                schedulingDto.Users = _mapper.Map<List<UserDto>>(users);
                schedulingDto.FormPayments = _mapper.Map<List<FormPaymentDto>>(formPayments);
                schedulingDto.TypeProcedures = _mapper.Map<List<TypeProcedureDto>>(typeProcedures);

                return View(schedulingDto);
            }

            await _schedulingService.CreateScheduling(_mapper.Map<Scheduling>(schedulingDto));

            return RedirectToAction(nameof(Index));
        }

        // GET: Scheduling/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduling = await _context.Scheduling.FindAsync(id);
            if (scheduling == null)
            {
                return NotFound();
            }
            ViewData["IdFormPayment"] = new SelectList(_context.FormPayment, "IdFormPayment", "Name", scheduling.IdFormPayment);
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "Address", scheduling.IdUser);
            return View(scheduling);
        }

        // POST: Scheduling/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdScheduling,Name,DtCreate,TotalValue,Observation,IdUser,IdFormPayment")] Scheduling scheduling)
        {
            if (id != scheduling.IdScheduling)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scheduling);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchedulingExists(scheduling.IdScheduling))
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
            ViewData["IdFormPayment"] = new SelectList(_context.FormPayment, "IdFormPayment", "Name", scheduling.IdFormPayment);
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "Address", scheduling.IdUser);
            return View(scheduling);
        }

        // GET: Scheduling/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduling = await _context.Scheduling
                .Include(s => s.IdFormPayment)
                .Include(s => s.IdUser)
                .FirstOrDefaultAsync(m => m.IdScheduling == id);
            if (scheduling == null)
            {
                return NotFound();
            }

            return View(scheduling);
        }

        // POST: Scheduling/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var scheduling = await _context.Scheduling.FindAsync(id);
            if (scheduling != null)
            {
                _context.Scheduling.Remove(scheduling);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchedulingExists(long id)
        {
            return _context.Scheduling.Any(e => e.IdScheduling == id);
        }
    }
}
