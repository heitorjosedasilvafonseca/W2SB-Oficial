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
    public class ProprietariosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Proprietarios
        public async Task<ActionResult> Index()
        {
            return View(await db.Proprietarios.ToListAsync());
        }

        // GET: Proprietarios/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprietario proprietario = await db.Proprietarios.FindAsync(id);
            if (proprietario == null)
            {
                return HttpNotFound();
            }
            return View(proprietario);
        }

        // GET: Proprietarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proprietarios/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProprietarioId,Nome,Celular,Endereco,Cidade,Uf,Rg,Cpf")] Proprietario proprietario)
        {
            if (ModelState.IsValid)
            {
                db.Proprietarios.Add(proprietario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(proprietario);
        }

        // GET: Proprietarios/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprietario proprietario = await db.Proprietarios.FindAsync(id);
            if (proprietario == null)
            {
                return HttpNotFound();
            }
            return View(proprietario);
        }

        // POST: Proprietarios/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProprietarioId,Nome,Celular,Endereco,Cidade,Uf,Rg,Cpf")] Proprietario proprietario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proprietario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(proprietario);
        }

        // GET: Proprietarios/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprietario proprietario = await db.Proprietarios.FindAsync(id);
            if (proprietario == null)
            {
                return HttpNotFound();
            }
            return View(proprietario);
        }

        // POST: Proprietarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Proprietario proprietario = await db.Proprietarios.FindAsync(id);
            db.Proprietarios.Remove(proprietario);
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
