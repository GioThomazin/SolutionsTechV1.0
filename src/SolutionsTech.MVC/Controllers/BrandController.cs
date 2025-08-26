using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Data.Context;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Controllers
{
	public class BrandController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;
		private readonly IBrandService _brandService;
		public BrandController(ApplicationDbContext context, IMapper mapper, IBrandService brandService)
		{
			_context = context;
			_mapper = mapper;
			_brandService = brandService;
		}

		//abrir uma regra geral, no caso, somente gerente vai ter visibilidade e exceções, como liberar metodos
		//  [Authorize(Roles = "Gerente")]
		public async Task<IActionResult> Index()
		{
			var listBrands = await _brandService.GetListIndex();
			return View(_mapper.Map<List<BrandDto>>(listBrands));
		}
		public async Task<IActionResult> Details(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var brand = await _context.Brand
				.FirstOrDefaultAsync(m => m.IdBrand == id);
			if (brand == null)
			{
				return NotFound();
			}

			return View(brand);
		}

		public IActionResult Create()
		{
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]

		public async Task<IActionResult> Create(BrandDto brandDto)
		{
			if (ModelState.IsValid)
			{
				var brand = _mapper.Map<Brand>(brandDto);
				await _brandService.CreateBrand(brand);
				return RedirectToAction(nameof(Index));
			}
			return View(brandDto);
		}
		public async Task<IActionResult> Edit(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var brand = await _context.Brand.FindAsync(id);
			if (brand == null)
			{
				return NotFound();
			}
			return View(brand);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(long id, [Bind("IdBrand,Name,DtCreate,Active,Size")] Brand brand)
		{
			if (id != brand.IdBrand)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(brand);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!BrandExists(brand.IdBrand))
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
			return View(brand);
		}

		public async Task<IActionResult> Delete(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var brand = await _context.Brand
				.FirstOrDefaultAsync(m => m.IdBrand == id);
			if (brand == null)
			{
				return NotFound();
			}

			return View(brand);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(long id)
		{
			if (id == 0)
			{
				return NotFound();
			}

			var brand = await _context.Brand.FindAsync(id);
			if (brand == null)
			{
				return NotFound();
			}

			_context.Brand.Remove(brand);
			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		private bool BrandExists(long id)
		{
			return _context.Brand.Any(e => e.IdBrand == id);
		}
	}
}