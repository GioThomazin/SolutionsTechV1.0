using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Controllers
{
    public class TypeProcedureController : BaseController
    {
        private readonly ITypeProcedureService _typeProcedureService;
        private readonly IMapper _mapper;
        private readonly INotificador _notificador;

        public TypeProcedureController(ITypeProcedureService typeProcedureService,
            IMapper mapper, INotificador notificador) : base(notificador)
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
            return View(new TypeProcedureDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TypeProcedureDto typeProcedureDto)
        {
            await _typeProcedureService.CreateTypeProcedure(_mapper.Map<TypeProcedure>(typeProcedureDto));

            if (!OperacaoValida()) return View(typeProcedureDto);

            TempData["Sucesso"] = "Tipo de procedimento criado com sucesso !";

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
                return NotFound();

            var typeProcedure = await _typeProcedureService.GetById(id.Value);

            if (typeProcedure == null)
                return NotFound();

            return View(_mapper.Map<TypeProcedureDto>(typeProcedure));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, TypeProcedureDto typeProcedureDto)
        {
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
