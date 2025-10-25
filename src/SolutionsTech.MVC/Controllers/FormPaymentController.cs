using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Business.Services;
using SolutionsTech.Data.Context;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Controllers
{
    public class FormPaymentController : Controller
    {
        private readonly IFormPaymentService _formPaymentService;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public FormPaymentController(IFormPaymentService formPaymentService, ApplicationDbContext context, IMapper mapper)
        {
            _formPaymentService = formPaymentService;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var listFormPayments = await _formPaymentService.GetListIndex();
            return View(_mapper.Map<List<FormPaymentDto>>(listFormPayments));
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
                return NotFound();

            var formPayment = await _formPaymentService.GetById(id.Value);

            if (formPayment == null)
                return NotFound();

            return View(formPayment);
        }

        public async Task<IActionResult> Create()
        {
            var formPayment = await _formPaymentService.GetListIndex();
            if(formPayment == null)
                return NotFound();

			return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FormPaymentDto formPaymentDto)
		{
			if (ModelState.IsValid)
			{
				var formPayment = _mapper.Map<FormPayment>(formPaymentDto);
				await _formPaymentService.CreateFormPayment(formPayment);
				return RedirectToAction(nameof(Index));
			}
			return View(formPaymentDto);
		}
		public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
                return NotFound();

            var formPayment = await _formPaymentService.GetById(id.Value);

            if (formPayment == null)
                return NotFound();

            return View(formPayment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, FormPaymentDto formPaymentDto)
        {
			if (id != formPaymentDto.IdFormPayment)
				return BadRequest();

			if (!ModelState.IsValid)
				return View(formPaymentDto);

			var existingFormPayment = await _formPaymentService.GetById(id);
			if (existingFormPayment == null)
				return NotFound();

            existingFormPayment.Name = formPaymentDto.Name;
            existingFormPayment.Active = formPaymentDto.Active;

            await _formPaymentService.UpdateFormPayment(existingFormPayment);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if(id == null)
                return NotFound();
            
            var formPayment = await _formPaymentService.GetById(id.Value);
            
            if (formPayment == null)
                return NotFound();

            return View(_mapper.Map<FormPaymentDto>(formPayment));

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var formPaymentDelete = await _formPaymentService.GetById(id);
            
            if (formPaymentDelete != null)
                await _formPaymentService.DeleteFormPayment(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
