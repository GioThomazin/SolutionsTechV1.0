using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Data.Context;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Controllers
{
	public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProductController(
            IProductService productService,
            ApplicationDbContext context,
            IMapper mapper)
        {
			_productService = productService;
			_context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var produtctList = await _productService.GetListIndex();
			return View(_mapper.Map<List<ProductDto>>(produtctList));
		}

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
                return NotFound();

            var product = await _productService.GetById(id.Value);

            if (product == null)
                return NotFound();

            return View(product);
        }

		public async Task<IActionResult> Create()
		{
			var productDto = new ProductDto();

			var brands = await _context.Brand.ToListAsync();
			var brandsDto = _mapper.Map<List<BrandDto>>(brands);

			productDto.Brands = brandsDto;

			return View(productDto);
		}

		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
				_context.Add(_mapper.Map<Product>(productDto));
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			var brands = await _context.Brand.ToListAsync();
			productDto.Brands = _mapper.Map<List<BrandDto>>(brands);

			return View(productDto);
        }

        public async Task<IActionResult> Edit(long? id)
        {
			if (id == null)
			{
				return NotFound();
			}

			var user = _mapper.Map<ProductDto>(await _context.Product.FindAsync(id));

			if (user == null)
			{
				return NotFound();
			}

			var brands = _mapper.Map<List<BrandDto>>(await _context.Brand.ToListAsync());
			user.Brands = brands;

			return View(user);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, ProductDto productDto)
        {
            if (id != productDto.IdProduct)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
					_context.Update(_mapper.Map<Product>(productDto));
					await _context.SaveChangesAsync();
				}
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(productDto.IdProduct))
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
            return View(productDto);
        }
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.IdProduct == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(long id)
        {
            return _context.Product.Any(e => e.IdProduct == id);
        }
    }
}
