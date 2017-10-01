using System.Web.Mvc;
using WebGrease.Css.Ast.Selectors;

namespace ExpressionTreesDemo.Web.Controllers
{
  public class HomeController : Controller
  {
    public HomeController()
    {
      
    }
    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }

    public ActionResult Index()
    {
      if (Session["Version"] == null)
        Session["Version"] = "Version1";
      return View(Session["Version"]);
    }

    public ActionResult SelectVersion1()
    {
      Session["Version"] = "Version1";
      return View("Index", Session["Version"]);
    }

    public ActionResult SelectVersion2()
    {
      Session["Version"] = "Version2";
      return View("Index", Session["Version"]);
    }

    public ActionResult SelectVersion3()
    {
      Session["Version"] = "Version3";
      return View("Index", Session["Version"]);
    }
  }
}