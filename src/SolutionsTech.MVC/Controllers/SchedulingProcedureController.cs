using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Business.Interfaces;
using SolutionsTech.Data.Context;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Controllers
{
    public class SchedulingProcedureController : Controller
    {
        private readonly ISchedulingProcedureService _schedulingProcedureService;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SchedulingProcedureController(ISchedulingProcedureService schedulingProcedureService, ApplicationDbContext context, IMapper mapper)
        {
            _schedulingProcedureService = schedulingProcedureService;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var listSchedulingProcedure = await _schedulingProcedureService.GetListIndex();
            return View(_mapper.Map<List<SchedulingProcedureDto>>(listSchedulingProcedure));
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
                return NotFound();

            var schedulingProcedure = await _schedulingProcedureService.GetById(id.Value);

            if (schedulingProcedure == null)
                return NotFound();

            return View(schedulingProcedure);
        }

        public IActionResult Create()
        {
            var schedulingProcedures = _schedulingProcedureService.GetListIndex();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SchedulingProcedureDto schedulingProcedureDto)
        {
            if (!ModelState.IsValid)
            {
                var schedulingProcedure = await _schedulingProcedureService.GetListIndex();
                return View(schedulingProcedureDto);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
                return NotFound();

            var schedulingProcedure = await _schedulingProcedureService.GetById(id.Value);

            if (schedulingProcedure == null)
                return NotFound();

            return View(schedulingProcedure);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, SchedulingProcedureDto schedulingProcedureDto)
        {

            if (!ModelState.IsValid)
                return NotFound();
            var schedulingProcedure = new SchedulingProcedure()
            {
                IdSchedulingProcedure = schedulingProcedureDto.IdSchedulingProcedure,
                IdScheduling = schedulingProcedureDto.IdSchedulingProcedure,
                IdTypeProcedure = schedulingProcedureDto.IdTypeProcedure
            };
            await _schedulingProcedureService.UpdateSchedulingProcedure(schedulingProcedure);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(long? id)
        {
            var schedulingProcedure = await _schedulingProcedureService.GetById(id.Value);

            if (schedulingProcedure == null)
                return NotFound();

            return View(_mapper.Map<SchedulingProcedureDto>(schedulingProcedure));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var schedulingProcedure = await _schedulingProcedureService.GetById(id);

            if (schedulingProcedure != null)
                await _schedulingProcedureService.DeleteSchedulingProcedure(id);

            return RedirectToAction(nameof(Index));
        }
    }
}