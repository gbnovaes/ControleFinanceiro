using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using SistemaFinanceiroUGB232.Data;
using SistemaFinanceiroUGB232.Models;

namespace SistemaFinanceiroUGB232.Controllers
{
    public class InstituicaoController : Controller
    {
        private readonly AcademicoContext _context;

        public InstituicaoController(AcademicoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Instituicoes.OrderBy(i => i.Nome).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome", "Endereco")] Instituicao instituicao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(instituicao);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("Erro de Cadastro.", "Não foi possível cadastrar a instituição");
                throw;
            }
            return View(instituicao);
        }
        public async Task<ActionResult> Edit(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var instituicao = await _context.Instituicoes.SingleOrDefaultAsync(i => i.InstituicaoID == id);
            if (instituicao == null)
            {
                return NotFound();
            }
            return View(instituicao);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("InstituicaoID", "Nome", "Endereco")] Instituicao instituicao)
        {
            if (id != instituicao.InstituicaoID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instituicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstituicaoExists(instituicao.InstituicaoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(instituicao);
        }

        bool InstituicaoExists(long? instituicaoID)
        {
            throw new NotImplementedException();
        }
    }

    //    public IActionResult Details(long id)
    //    {
    //        return View(instituicoes.Where(i => i.InstituicaoID == id).First());
    //    }
    //    public IActionResult Delete(long id)
    //    {
    //        return View(instituicoes.Where(i => i.InstituicaoID == id).First());
    //    }
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult Delete(Instituicao instituicao)
    //    {
    //        instituicoes.Remove(instituicoes.Where(i => i.InstituicaoID == instituicao.InstituicaoID).First());
    //        return RedirectToAction("Index");
    //    }
    //}
}
