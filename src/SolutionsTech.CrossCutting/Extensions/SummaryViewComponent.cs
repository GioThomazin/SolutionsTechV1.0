
using Microsoft.AspNetCore.Mvc;

namespace SolutionsTech.CrossCutting.Extensions;

public class SummaryViewComponent : ViewComponent
{
    public SummaryViewComponent()
    {

    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}