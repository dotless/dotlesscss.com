using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dotless.Core;
using dotless.Core.configuration;
using dotlesscss.com.Documentation;
using dotlesscss.com.Models;

namespace dotlesscss.com.Controllers
{
  public class HomeController : Controller
  {
    [OutputCache(Duration = 86400, VaryByParam="None")]
    public ActionResult Index()
    {
      return View();
    }

    [OutputCache(Duration = 86400, VaryByParam = "None")]
    public ActionResult Docs()
    {
      return View("Docs", ChapterModel.FromChaperList(DataSource.Chapters));
    }

    public ActionResult Reference(string chapterName, string topicName)
    {
      return Reference(null, chapterName, topicName);
    }

    [HttpPost]
    public ActionResult Reference(TopicModel model, string chapterName, string topicName)
    {
      // Show all Chapters ------------------------------------------------------------
      var chapter = DataSource.FindChapter(chapterName);
      if (chapter == null)
        return View("Docs", ChapterModel.FromChaperList(DataSource.Chapters));

      // Show all Topics for Chapter --------------------------------------------------
      var topic = DataSource.FindTopic(chapter, topicName);
      if (topic == null)
        return View("Chapter", new ChapterModel(chapter));

      // Show Topics details ----------------------------------------------------------
      var topicModel = new TopicModel(topic) { All = ChapterModel.FromChaperList(DataSource.Chapters) };

      if (model != null)
        topicModel.ExampleLess = model.ExampleLess.Trim();

      try
      {
        topicModel.ExampleCss = ProcessLess(topicModel.ExampleLess);
      }
      catch (Exception ex)
      {
        topicModel.ExampleCss = string.Empty;
      }

      return View("Topic", topicModel);
    }

    public ActionResult TryIt()
    {
      var defaultHtml = @"
<div id=""example1"">Mouse over me!</div>
<div id=""example2"">Mouse over me!</div>
<div id=""example3"">Mouse over me!</div>
";
      var defaultLess = @"
@base_color: #cc8844;
#example1 {
  background: @base_color;
  &:hover { background: saturation(@base_color, 50%); }
}
#example2 {
  background: @base_color;
  &:hover { background: lightness(@base_color, 30%); }
}
#example3 {
  background: @base_color;
  &:hover { background: hue(@base_color, -70); }
}
";
      return TryIt(defaultHtml, defaultLess);
    }

    [HttpPost]
    [ValidateInput(false)]
    public ActionResult TryIt(string html, string less)
    {
      ViewData["less"] = less.Trim();
      ViewData["css"] = ProcessLess(less);
      ViewData["html"] = html.Trim();

      return View();
    }

    public string ProcessLess(string less)
    {
      return Less.Parse(less);
    }
  }
}
