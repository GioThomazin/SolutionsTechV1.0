using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Data.Context;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Controllers
{
	public class SchedulingController : Controller
	{
		private readonly ISchedulingService _schedulingService;
		private readonly IUserService _userService;
		private readonly IFormPaymentService _formPaymentService;
		private readonly ITypeProcedureService _typeProcedureService;
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public SchedulingController(ApplicationDbContext context,
			IMapper mapper,
			ISchedulingService schedulingService,
			IUserService userService,
			IFormPaymentService formPaymentService,
			ITypeProcedureService typeProcedureService
			)
		{
			_context = context;
			_mapper = mapper;
			_schedulingService = schedulingService;
			_userService = userService;
			_formPaymentService = formPaymentService;
			_typeProcedureService = typeProcedureService;
		}

		public async Task<IActionResult> Index()
		{
			var list = await _schedulingService.GetListIndex();
			return View(_mapper.Map<List<SchedulingDto>>(list));
		}

		public async Task<IActionResult> Details(long? id)
		{
			if (id == null)
				return NotFound();

			var scheduling = await _schedulingService.GetById(id.Value);

			if (scheduling == null)
				return NotFound();

			return View(scheduling);
		}
		public async Task<IActionResult> Create()
		{
			var users = await _userService.GetListIndex();
			var formPayments = await _formPaymentService.GetListIndex();
			var typeProcedures = await _typeProcedureService.GetListIndex();

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
				var users = await _userService.GetListIndex();
				var formPayments = await _formPaymentService.GetListIndex();
				var typeProcedures = await _typeProcedureService.GetListIndex();
				return View(schedulingDto);
			}

			await _schedulingService.CreateScheduling(_mapper.Map<Scheduling>(schedulingDto));

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(long? id)
		{
			if (id == null)
				return NotFound();

			var schedulingEdit = await _schedulingService.GetById(id.Value);

			if (schedulingEdit == null)
				return NotFound();

			var dto = _mapper.Map<SchedulingDto>(schedulingEdit);

			dto.Users = _mapper.Map<List<UserDto?>>(await _userService.GetListIndex());
			dto.FormPayments = _mapper.Map<List<FormPaymentDto?>>(await _formPaymentService.GetListIndex());
			dto.TypeProcedures = _mapper.Map<List<TypeProcedureDto?>>(await _typeProcedureService.GetListIndex());

			return View(dto);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(long id, SchedulingDto schedulingDto)
		{
			ModelState.Remove("FormPayment.Name");

			if (id != schedulingDto.IdScheduling)
				return BadRequest();

			if (!ModelState.IsValid)
				return View(schedulingDto);

			var schedulingExisting = await _schedulingService.GetById(id);
			if (schedulingExisting == null)
				return NotFound();

			schedulingExisting.DtCreate = schedulingDto.DtCreate;
			schedulingExisting.TotalValue = schedulingDto.TotalValue;
			schedulingExisting.Observation = schedulingDto.Observation;
			schedulingExisting.IdUser = schedulingDto.IdUser;

			await _schedulingService.UpdateScheduling(schedulingExisting);

			return RedirectToAction(nameof(Index));
		}

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
			ModelState.Clear(); 

			var scheduling = await _schedulingService.GetById(id);

			if (scheduling != null)
				await _schedulingService.DeleteScheduling(id);

			return RedirectToAction(nameof(Index));
		}
	}
}
