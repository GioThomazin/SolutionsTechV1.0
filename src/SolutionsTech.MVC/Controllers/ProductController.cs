using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Data.Context;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Controllers
{
	public class ProductController : BaseController
	{
		private readonly IProductService _productService;
		private readonly IBrandService _brandService;
		private readonly IMapper _mapper;
		public ProductController(IMapper mapper, IProductService productService, IBrandService brandService, INotificador notificador) : base(notificador)
		{
			_mapper = mapper;
			_productService = productService;
			_brandService = brandService;
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
			var products = await _productService.GetListIndex();

			if (products == null)
				return NotFound();

			var productDto = new ProductDto
			{
				Brands = _mapper.Map<IEnumerable<BrandDto>>(await _brandService.GetListIndex())
			};
			ModelState.Clear();
			return View(products);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ProductDto productDto)
		{
			await _productService.CreateProduct(_mapper.Map<Product>(productDto));

			if (!OperacaoValida()) return View(productDto);

			TempData["Sucesso"] = "Produto criado com sucesso!";

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(long? id)
		{
			if (id == null)
				return NotFound();

			var product = await _productService.GetById(id.Value);

			if (product == null)
				return NotFound();

			var productnew = new ProductDto
			{
				IdProduct = product.IdProduct,
				Name = product.Name,
				Size = product.Size,
				Active = product.Active,
				IdBrand = product.IdBrand,
				DtCreate = product.DtCreate,
			};

			return View(productnew);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(long id, ProductDto productDto)
		{
			if (id != productDto.IdProduct)
				return NotFound();

			var existingProduct = await _productService.GetById(id);
			if (existingProduct == null)
				return NotFound();

			existingProduct.Name = productDto.Name;
			existingProduct.Size = productDto.Size;
			existingProduct.Active = productDto.Active;

			await _productService.UpdateProduct(existingProduct);

			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Delete(long id)
		{
			var productDelete = await _productService.GetById(id);

			if (id == null)
				return NotFound();

			return View(_mapper.Map<ProductDto>(productDelete));
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(long id)
		{
			var product = await _productService.GetById(id);

			if (product != null)
				await _productService.DeleteProduct(id);

			return RedirectToAction(nameof(Index));
		}
	}
}
