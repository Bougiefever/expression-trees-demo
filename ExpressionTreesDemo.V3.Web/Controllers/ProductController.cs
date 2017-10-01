using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpressionTreesDemo.Data.Query;
using ExpressionTreesDemo.Data.V3;
using ExpressionTreesDemo.V3.Web.Models;

namespace ExpressionTreesDemo.V3.Web.Controllers
{
    public class ProductController : Controller
    {
    private RepositoryV3 _repository;

    public RepositoryV3 Repository
    {
      get
      {
        _repository = _repository ?? new RepositoryV3();
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
      var filters = model.SelectedCategoryTypes.Select(c => Enum.Parse(typeof(CategoryType), c)).Cast<CategoryType>().Where(c => c != CategoryType.Green).Select(ct => new FilterItem("CategoryType", ct)).ToList();
      if (model.SelectedCategoryTypes.Contains("Green"))
        filters.Add(new FilterItem("Green", "Green"));

      if (!string.IsNullOrEmpty(model.Keyword))
        filters.Add(new FilterItem("Keyword", model.Keyword));

      if (!string.IsNullOrEmpty(model.Color))
        filters.Add(new FilterItem("Color", model.Color));


      var products = Repository.DynamicFieldSelection(filters.ToArray());
      model.Products = products.ToList();
      model.Categories = Repository.Categories.ToList();
      model.Products = products.ToList();

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
      var products = Repository.DynamicFieldSelection(new FilterItem("Id", model.SelectedId, typeof(int)));
      model.Products = products.ToList();
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
      var products = Repository.DynamicFieldSelection(new FilterItem("Name", model.SelectedName));
      model.Products = products.ToList();
      return View(model);
    }
  }
}