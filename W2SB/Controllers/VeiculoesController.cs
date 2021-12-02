using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using W2SB.Data;
using W2SB.Models;

namespace W2SB.Controllers
{
    public class VeiculoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Veiculoes
        public async Task<ActionResult> Index()
        {
            var veiculoes = db.Veiculoes.Include(v => v.proprietario);
            return View(await veiculoes.ToListAsync());
        }

        // GET: Veiculoes/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = await db.Veiculoes.FindAsync(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // GET: Veiculoes/Create
        public ActionResult Create()
        {
            ViewBag.ProprietarioId = new SelectList(db.Proprietarios, "ProprietarioId", "Nome");
            return View();
        }

        // POST: Veiculoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VeiculoId,Marca,Modelo,Ano,Cor,Combustivel,ProprietarioId")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Veiculoes.Add(veiculo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProprietarioId = new SelectList(db.Proprietarios, "ProprietarioId", "Nome", veiculo.ProprietarioId);
            return View(veiculo);
        }

        // GET: Veiculoes/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = await db.Veiculoes.FindAsync(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProprietarioId = new SelectList(db.Proprietarios, "ProprietarioId", "Nome", veiculo.ProprietarioId);
            return View(veiculo);
        }

        // POST: Veiculoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VeiculoId,Marca,Modelo,Ano,Cor,Combustivel,ProprietarioId")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veiculo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProprietarioId = new SelectList(db.Proprietarios, "ProprietarioId", "Nome", veiculo.ProprietarioId);
            return View(veiculo);
        }

        // GET: Veiculoes/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = await db.Veiculoes.FindAsync(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // POST: Veiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Veiculo veiculo = await db.Veiculoes.FindAsync(id);
            db.Veiculoes.Remove(veiculo);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
