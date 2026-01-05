using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Controllers
{
    public class FormPaymentController : BaseController
    {
        private readonly IFormPaymentService _formPaymentService;
        private readonly IMapper _mapper;


        public FormPaymentController(IMapper mapper, IFormPaymentService formPaymentService, INotificador notificador) : base(notificador)
		{
            _mapper = mapper;
            _formPaymentService = formPaymentService;
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

			return View(formPayment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FormPaymentDto formPaymentDto)
		{
            await _formPaymentService.CreateFormPayment(_mapper.Map<FormPayment>(formPaymentDto));
            
            if(!OperacaoValida())
                return View(formPaymentDto);

            TempData["Sucesso"] = "Forma de pagamento criada com sucesso!";
			
            return RedirectToAction(nameof(Index));
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
