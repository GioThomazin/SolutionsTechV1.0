using Microsoft.AspNetCore.Mvc;
using SolutionsTech.Business.Interfaces;

namespace SolutionsTech.MVC.Controllers;

public abstract class BaseController : Controller
{
    private readonly INotificador _notificador;

    protected BaseController(INotificador notificador)
    {
        _notificador = notificador;
    }

    protected bool OperacaoValida()
    {
        return !_notificador.TemNotificacao();
    }
}