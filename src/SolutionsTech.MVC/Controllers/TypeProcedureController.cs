using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Controllers
{
	public class TypeProcedureController : Controller
	{
		private readonly ITypeProcedureService _typeProcedureService;
		private readonly IMapper _mapper;
		public TypeProcedureController(ITypeProcedureService typeProcedureService, IMapper mapper)
		{
			_typeProcedureService = typeProcedureService;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			var typeProcedures = await _typeProcedureService.GetListIndex();
			return View(_mapper.Map<List<TypeProcedureDto>>(typeProcedures));
		}

		public async Task<IActionResult> Details(long? id)
		{
			if (id == null)
				return NotFound();

			var typeProcedure = await _typeProcedureService.GetById(id.Value);

			if (typeProcedure == null)
				return NotFound();

			return View(typeProcedure);
		}

		public IActionResult Create()
		{
			var schedulingProcedures = _typeProcedureService.GetListIndex();
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(TypeProcedureDto typeProcedureDto)
		{
			if (ModelState.IsValid)
			{
				var typeProcedure = await _typeProcedureService.GetListIndex();
				return View(typeProcedure);
			}
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(long? id)
		{
			if (id == null)
				return NotFound();

			var typeProcedure = await _typeProcedureService.GetById(id.Value);

			if (typeProcedure == null)
				return NotFound();

			return View(typeProcedure);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(long id, TypeProcedureDto typeProcedureDto)
		{
			if (ModelState.IsValid)
				return NotFound();
			var typeProcedure = new TypeProcedure()
			{
				IdTypeProcedure = typeProcedureDto.IdTypeProcedure,
				Name = typeProcedureDto.Name,
				Value = typeProcedureDto.Value,
				Duration = typeProcedureDto.Duration
			};

			await _typeProcedureService.UpdateTypeProcedure(typeProcedure);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(long? id)
		{
			var typeProcedure = await _typeProcedureService.GetById(id.Value);

			if (typeProcedure == null)
				return NotFound();

			return View(typeProcedure);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(long id)
		{
			var typeProcedure = await _typeProcedureService.GetById(id);

			if (typeProcedure != null)
				await _typeProcedureService.DeleteTypeProcedure(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
