using Microsoft.AspNetCore.Mvc;
using SistemaFinanceiroUGB232.Models;

namespace SistemaFinanceiroUGB232.Controllers
{
    public class DepartamentoController : Controller
    {
        public static IList<Departamento> departamentos = new List<Departamento>()
        {
            new Departamento()
            {
                DepartamentoID = 1,
                Nome = "Administrativo",
            },
            new Departamento()
            {
                DepartamentoID = 2,
                Nome = "Financeiro"
            }   
        };
        public IActionResult Index()
        {
            return View(departamentos);
        }
    }
}
