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
  [OutputCache(Duration = 86400, VaryByParam="None")]
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Docs(string chapterName, string topicName)
    {
      return Docs(null, chapterName, topicName);
    }

    [HttpPost]
    public ActionResult Docs(TopicModel model, string chapterName, string topicName)
    {
      // Show all Chapters ------------------------------------------------------------
      Chapter chapter = DataSource.FindChapter(chapterName);
      if (chapter == null)
        return View("Docs", DataSource.Chapters);

      // Show all Topics for Chapter --------------------------------------------------
      Topic topic = DataSource.FindTopic(chapter, topicName);
      if (topic == null)
        return View("Chapter", new ChapterModel(chapter));

      // Show Topics details ----------------------------------------------------------
      TopicModel topicModel = new TopicModel(topic) { All = DataSource.Chapters };

      if (model != null)
        topicModel.ExampleLess = model.ExampleLess;

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

    public string ProcessLess(string less)
    {
      var config = DotlessConfiguration.Default;
      config.MinifyOutput = false;
      var engine = (new EngineFactory()).GetEngine(config);
      var ob = new LessSourceObject { Content = less };

      return engine.TransformToCss(ob);
    }
  }
}
