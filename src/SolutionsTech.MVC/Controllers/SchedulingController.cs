using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Data.Context;
using SolutionsTech.MVC.Dto;
using SolutionsTech.MVC.Dtos.ViewModel;

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
		// fluxo financeiro, custo fixo criar controller crud
		//tenant por segmentação de cliente, salao de beleza, venda de produtos etc
		public async Task<IActionResult> Index()
		{
			var schedulings = await _context.Scheduling
				.Include(s => s.User)
				.Include(s => s.FormPayment)
				.Include(s => s.SchedulingProcedures)
				.Include(s => s.SchedulingProducts)
				.ToListAsync();

			var users = await _context.Users.Where(x => x.Active).ToListAsync();
			var formPayments = await _context.FormPayment.ToListAsync();
			var typeProcedures = await _context.TypeProcedure.ToListAsync();
			var schedulingProduct = await _context.SchedulingProduct.ToListAsync();

			var viewModel = new SchedulingView
			{
				Schedulings = _mapper.Map<List<SchedulingDto>>(schedulings),
				Users = _mapper.Map<List<UserDto>>(users),
				FormPayments = _mapper.Map<List<FormPaymentDto>>(formPayments),
				SchedulingProducts = _mapper.Map<List<SchedulingProductDto>>(schedulingProduct)
			};

			return View(viewModel);
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
				// Se a validação falhar, retorne novamente a view com dados necessários
				var users = await _context.Users.ToListAsync();
				var formPayments = await _context.FormPayment.ToListAsync();
				var typeProcedures = await _context.TypeProcedure.ToListAsync();

				schedulingDto.Users = _mapper.Map<List<UserDto>>(users);
				schedulingDto.FormPayments = _mapper.Map<List<FormPaymentDto>>(formPayments);
				schedulingDto.TypeProcedures = _mapper.Map<List<TypeProcedureDto>>(typeProcedures);

				return View(schedulingDto); // Retorne a view com o viewModel corrigido
			}

			// Adicione o agendamento ao contexto
			_context.Add(_mapper.Map<Scheduling>(schedulingDto));
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index)); // Redirecione para a página de index 
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
