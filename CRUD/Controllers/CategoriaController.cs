using CRUD.Core;
using CRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class CategoriaController : BaseController
    {
        public void IndexViewBags()
        {
            List<Categoria> categorias = UnitOfWork.CategoriaDal.ObterTodos().ToList();

            ViewBag.Categorias = categorias;
        }

        public ActionResult Index()
        {
            IndexViewBags();

            return View();
        }

        [HttpPost]
        public ActionResult Index(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.CategoriaDal.Adicionar(categoria);
                UnitOfWork.CategoriaDal.Salvar();

                IndexViewBags();

                return View();
            }

            return View();
        }

        public ActionResult Alterar(int id)
        {
            Categoria categoriaBanco = UnitOfWork.CategoriaDal.Obter(x => x.Id == id).FirstOrDefault();

            if(categoriaBanco != null)
            {
                return View(categoriaBanco);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Alterar(Categoria categoriaAlterada)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.CategoriaDal.Atualizar(categoriaAlterada);
                UnitOfWork.CategoriaDal.Salvar();

                return RedirectToAction("Index");
            }

            return View(categoriaAlterada);
        }

        public ActionResult Excluir(int id)
        {
            Categoria categoriaBanco = UnitOfWork.CategoriaDal.Obter(x => x.Id == id).FirstOrDefault();

            if(categoriaBanco != null)
            {
                return View(categoriaBanco);
            }

            return View();
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirCategoria(int id)
        {
            UnitOfWork.CategoriaDal.Excluir(x => x.Id == id);
            UnitOfWork.CategoriaDal.Salvar();

            return RedirectToAction("Index");
        }
    }
}