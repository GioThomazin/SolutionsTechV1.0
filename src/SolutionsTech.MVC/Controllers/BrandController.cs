using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
                return NotFound();

            var brand = await _brandService.GetById(id.Value);

            if (brand == null)
                return NotFound();

            return View(brand);
        }

        public async Task<IActionResult> Create()
        {
            var brands = await _brandService.GetListIndex();
            if (brands == null)
                return NotFound();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(BrandDto brandDto)
        {
            var brand = _mapper.Map<Brand>(brandDto);

            var result = await _brandService.CreateBrand(brand);

            if (!string.IsNullOrEmpty(result))
            {
                return RedirectToAction(nameof(Create));
            }

            return View();
        }
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
                return NotFound();

            var brand = await _brandService.GetById(id.Value);
            if (brand == null)
                return NotFound();

            var brandnew = new BrandDto
            {
                IdBrand = brand.IdBrand,
                Name = brand.Name,
                Active = brand.Active
            };

            return View(brandnew);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, BrandDto brandDto)
        {
            if (id != brandDto.IdBrand)
                return BadRequest();

            var existingBrand = await _brandService.GetById(id);
            if (existingBrand == null)
                return NotFound();

            existingBrand.Name = brandDto.Name;
            existingBrand.Active = brandDto.Active;

            await _brandService.UpdateBrand(existingBrand);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(long id)
        {
            var brandDelete = await _brandService.GetById(id);

            if (brandDelete == null)
                return NotFound();

            return View(_mapper.Map<BrandDto>(brandDelete));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var brand = await _brandService.GetById(id);

            if (brand != null)
                await _brandService.DeleteBrand(id);

            return RedirectToAction(nameof(Index));
        }
    }
}