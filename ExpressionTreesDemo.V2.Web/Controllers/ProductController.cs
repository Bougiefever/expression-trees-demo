using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpressionTreesDemo.Data.V2;
using ExpressionTreesDemo.Data.Query;
using ExpressionTreesDemo.V2.Web.Models;

namespace ExpressionTreesDemo.V2.Web.Controllers
{
    public class ProductController : Controller
    {
    private RepositoryV2 _repository;

    public RepositoryV2 Repository
    {
      get
      {
        _repository = _repository ?? new RepositoryV2();
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

        var products = Repository.DynamicFieldSelectWithSortOption(new FilterItem("CategoryType", type), model.SortOption);
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