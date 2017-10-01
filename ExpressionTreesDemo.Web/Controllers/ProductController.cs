using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ExpressionTreesDemo.Data.V1;
using ExpressionTreesDemo.Web.Models;

namespace ExpressionTreesDemo.Web.Controllers
{
  public class ProductController : Controller
  {
    private RepositoryV1 _repository;

    public ProductController()
    {
       _repository = new RepositoryV1();
    }

    public RepositoryV1 Repository
    {
      get
      {
        _repository = _repository ?? new RepositoryV1();
        return _repository;
      }
    }

    [HttpGet]
    public ActionResult CategorySelection()
    {
      var model = new CategorySelectionModel();

      model.Categories = Repository.Categories.ToList();
      model.Products = new List<Product>();
      model.SelectedCategoryTypes = new List<string>();
      return View(model);
    }

    [HttpPost]
    public ActionResult CategorySelection(CategorySelectionModel model)
    {
      var type = (CategoryType)Enum.Parse(typeof(CategoryType), model.SelectedCategoryTypes.First());
      var products = Repository.DynamicFieldSelection("Category", type.ToString());


      model.Products = products.ToList();

      model.Categories = Repository.Categories.ToList();
      return View("CategorySelection", model);
    }

    [HttpGet]
    public ActionResult IdSelection()
    {
      var model = new IdSelectionModel();
      model.Products = new List<Product>();
      return View(model);
    }

    [HttpPost]
    public ActionResult IdSelection(IdSelectionModel model)
    {
      var product = Repository.GetById(model.SelectedId);
      model.Products = new[] { product }.ToList();
      return View(model);
    }

    public ActionResult NameSelection()
    {
      var model = new NameSelectionModel();
      model.Products = new List<Product>();

      return View(model);
    }

    [HttpPost]
    public ActionResult NameSelection(NameSelectionModel model)
    {
      var product = Repository.GetByName(model.SelectedName);
      model.Products = new[] { product }.ToList();
      return View(model);
    }
  }
}