using CRUD.Core;
using CRUD.Dal.Contexto;
using CRUD.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class ProdutoController : BaseController
    {
        public void SetCategoriesViewBag()
        {
            List<Categoria> listaCategorias = UnitOfWork.CategoriaDal.ObterTodos().ToList();

            List<SelectListItem> categorias = new List<SelectListItem>();
            foreach(var item in listaCategorias)
            {
                categorias.Add(new SelectListItem { Text = item.Descricao, Value = item.Id.ToString() });
            }

            ViewBag.Categorias = categorias;
        }

        public void SetProductsViewBags()
        {
            List<Produto> produtos = UnitOfWork.ProdutoDal.ObterTodos().ToList();

            ViewBag.Produtos = produtos;
        }

        public ActionResult Index()
        {
            SetCategoriesViewBag();
            SetProductsViewBags();

            return View();
        }

        [HttpPost]
        public ActionResult Index(Produto produto)
        {
            if (ModelState.IsValid)
            {
                using(var transaction = new Entities().Database.BeginTransaction())
                {
                    try
                    {
                        UnitOfWork.ProdutoDal.Adicionar(produto);
                        UnitOfWork.ProdutoDal.Salvar();
                        
                        transaction.Commit();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

                SetCategoriesViewBag();
                SetProductsViewBags();

                return View();
            }

            return View(produto);
        }

        public ActionResult Alterar(int id)
        {
            SetCategoriesViewBag();

            Produto produtoBanco = UnitOfWork.ProdutoDal.Obter(x => x.Id == id).FirstOrDefault();

            if(produtoBanco != null)
            {
                return View(produtoBanco);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Alterar(Produto produtoAlterado)
        {
            SetCategoriesViewBag();

            if (ModelState.IsValid)
            {
                using(var transaction = new Entities().Database.BeginTransaction())
                {
                    try
                    {
                        UnitOfWork.ProdutoDal.Atualizar(produtoAlterado);
                        UnitOfWork.CategoriaDal.Salvar();

                        transaction.Commit();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

                return RedirectToAction("Index");
            }

            return View(produtoAlterado);
        }

        public ActionResult Excluir(int id)
        {
            Produto produtoBanco = UnitOfWork.ProdutoDal.Obter(x => x.Id == id).FirstOrDefault();

            if(produtoBanco != null)
            {
                ViewBag.Categoria = UnitOfWork.CategoriaDal.Obter(x => x.Id == produtoBanco.CategoriaId).FirstOrDefault().Descricao;

                return View(produtoBanco);
            }

            return View();
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirProduto(int id)
        {
            using(var transaction = new Entities().Database.BeginTransaction())
            {
                try
                {
                    int idCategoria = UnitOfWork.ProdutoDal.Obter(x => x.Id == id).FirstOrDefault().CategoriaId;
                    ViewBag.Categoria = UnitOfWork.CategoriaDal.Obter(x => x.Id == idCategoria).FirstOrDefault().Descricao;

                    UnitOfWork.ProdutoDal.Excluir(x => x.Id == id);
                    UnitOfWork.ProdutoDal.Salvar();

                    transaction.Commit();
                }
                catch (DbEntityValidationException ex)
                {
                    transaction.Rollback();
                    throw;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            
            return RedirectToAction("Index");
        }

    }
}