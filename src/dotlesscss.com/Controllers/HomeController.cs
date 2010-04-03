using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dotlesscss.com.Controllers
{
  [OutputCache(Duration = 86400, VaryByParam="None")]
  public class HomeController : Controller
  {
    //
    // GET: /Home/

    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Docs()
    {
      return View();
    }
  }
}
