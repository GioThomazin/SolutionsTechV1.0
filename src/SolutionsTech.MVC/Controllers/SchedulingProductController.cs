using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Data.Context;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Controllers
{
	public class SchedulingProductController : Controller
	{
		private readonly ISchedulingProductService _schedulingProductService;
		private readonly IMapper _mapper;
		public SchedulingProductController(ISchedulingProductService schedulingProductService, IMapper mapper)
		{
			_schedulingProductService = schedulingProductService;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			var list = await _schedulingProductService.GetListIndex();
			return View(_mapper.Map<List<SchedulingProductDto>>(list));
		}

		public async Task<IActionResult> Details(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var schedulingProduct = await _schedulingProductService.GetById(id.Value);

			if (schedulingProduct == null)
				return NotFound();

			return View(schedulingProduct);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(SchedulingProductDto schedulingProductDto)
		{
			if (ModelState.IsValid)
			{
				var schedulingProduct = await _schedulingProductService.GetListIndex();
				return View(schedulingProduct);
			}
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Edit(long? id)
		{
			if (id == null)
				return NotFound();

			var schedulingProduct = await _schedulingProductService.GetById(id.Value);

			if (schedulingProduct == null)
				return NotFound();

			return View(schedulingProduct);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(long id, SchedulingProductDto schedulingProductDto)
		{
			if (ModelState.IsValid)
				return NotFound();
			var schedulingProduct = new SchedulingProduct()
			{
				IdSchedulingProduct = schedulingProductDto.IdSchedulingProduct,
				IdScheduling = schedulingProductDto.IdScheduling,
				IdProduct = schedulingProductDto.IdProduct
			};

			return View(schedulingProduct);
		}

		public async Task<IActionResult> Delete(long? id)
		{
			var schedulingProduct = await _schedulingProductService.GetById(id.Value);

			if (id == null)
				return NotFound();

			return View(_mapper.Map<SchedulingProductDto>(schedulingProduct));
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(long id)
		{
			var schedulingProduct = await _schedulingProductService.GetById(id);

			if (schedulingProduct != null)
				_schedulingProductService.DeleteSchedulingProduct(id);

			return RedirectToAction(nameof(Index));
		}
	}
}
