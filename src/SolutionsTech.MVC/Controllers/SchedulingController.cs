using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Data.Context;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Controllers
{
	public class SchedulingController : Controller
    {
        private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public SchedulingController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //menu configurações com forma de pagamento,castrado de user, tipo de user - DONEx
        //procedimento adicionais -NAO VAI PRECISAR, PORQUE O PROCEDIMENTO, VAI TER DROPDOWN
        // fluxo financeiro, custo fixo criar controller crud
        //inseirr data nascimento - DONE
        //tenant
        //inserir campo email no client - DONE
        public async Task<IActionResult> Index()
		{
			// Carrega todos os agendamentos com os dados relacionados (User e FormPayment)
			var schedulings = await _context.Scheduling
				.Include(s => s.User)          // Carrega os dados do usuário relacionado
				.Include(s => s.FormPayment)    // Carrega os dados da forma de pagamento relacionada
				.Where(s => s.User.Active && s.FormPayment.Active) // Filtra apenas ativos
				.OrderByDescending(s => s.DtCreate) // Ordena por data mais recente
				.ToListAsync();

			// Mapeia para o DTO e retorna para a view
			return View(_mapper.Map<List<SchedulingDto>>(schedulings));
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

        // GET: Scheduling/Create
        public async Task<IActionResult> Create()
        {
			var schedulingDto = new SchedulingDto();

			var users = await _context.Users.ToListAsync();
			var usersDto = _mapper.Map<List<UserDto>>(users);

			schedulingDto.Users = usersDto;

            var formPayments = await _context.FormPayment.ToListAsync();
            var formPaymentsDto = _mapper.Map<List<FormPaymentDto>>(formPayments);

            schedulingDto.FormPayments = formPaymentsDto;

			return View(schedulingDto);
		}

        // POST: Scheduling/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SchedulingDto schedulingDto)
        {
			if (!ModelState.IsValid)
			{
				schedulingDto.Users = _mapper.Map<List<UserDto>>(await _context.Users.ToListAsync());
				schedulingDto.FormPayments = _mapper.Map<List<FormPaymentDto>>(await _context.FormPayment.ToListAsync());
				return View(schedulingDto);
			}

			_context.Add(_mapper.Map<User>(schedulingDto));
			_context.Add(_mapper.Map<FormPayment>(schedulingDto));
			await _context.SaveChangesAsync();
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
