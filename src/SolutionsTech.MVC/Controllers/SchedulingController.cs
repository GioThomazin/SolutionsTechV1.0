using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Data.Context;
using SolutionsTech.MVC.Dto;

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
				TypeProcedures = _mapper.Map<List<TypeProcedureDto>>(typeProcedures)
			};

			return View(viewModel);
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
				return View(schedulingDto);
			}

			var selectedProcedures = await _context.TypeProcedure
				.Where(tp => schedulingDto.SelectedTypeProcedureIds.Contains(tp.IdTypeProcedure))
				.ToListAsync();

			schedulingDto.TypeProcedures = _mapper.Map<List<TypeProcedureDto>>(selectedProcedures);

			await _schedulingService.CreateScheduling(_mapper.Map<Scheduling>(schedulingDto));

			return RedirectToAction(nameof(Index));
		}

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

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(long id, SchedulingDto scheduling)
		{
			if (id != scheduling.IdScheduling)
				return NotFound();

			if (!ModelState.IsValid)
				return View(scheduling);

			await _schedulingService.UpdateScheduling(_mapper.Map<Scheduling>(scheduling));

			return RedirectToAction(nameof(Index));
		}

		// GET: Scheduling/Delete/5
		public async Task<IActionResult> Delete(long id)
		{
			var schedulingDelete = await _schedulingService.GetById(id);

			if (schedulingDelete == null)
				return NotFound();

			return View(_mapper.Map<SchedulingDto>(schedulingDelete));
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(long id)
		{
			var scheduling = await _schedulingService.GetById(id);
			if (scheduling != null)

			await _schedulingService.DeleteScheduling(id);

			return RedirectToAction(nameof(Index));
		}
	}
}
