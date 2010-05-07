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
    public class DocumentationController : Controller
    {
		public ActionResult Home()
		{
			return View("Index");
		}

        public ActionResult Index(string chapterName, string topicName)
        {
            return DoStuff(chapterName, topicName, null);
        }

        [HttpPost]
        public ActionResult Index(TopicModel model, string chapterName, string topicName)
        {
            return DoStuff(chapterName, topicName, model);
        }

        public ActionResult DoStuff(string chapterName, string topicName, TopicModel postback)
        {
            // Show all Chapters ------------------------------------------------------------
            Chapter chapter = DataSource.FindChapter(chapterName);
            if (chapter == null)
                return View("Index", DataSource.Chapters);

            // Show all Topics for Chapter --------------------------------------------------
            Topic topic = DataSource.FindTopic(chapter, topicName);
            if (topic == null)
                return View("Chapter", new ChapterModel(chapter));

            // Show Topics details ----------------------------------------------------------
        	TopicModel topicModel = new TopicModel(topic) {All = DataSource.Chapters};

            if (postback != null)
                topicModel.ExampleLess = postback.ExampleLess;

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

        private string ProcessLess(string less)
        {
            DotlessConfiguration config = DotlessConfiguration.Default;
            config.MinifyOutput = false;
            ILessEngine engine = (new EngineFactory()).GetEngine(config);
            LessSourceObject ob = new LessSourceObject {Content = less};

            return engine.TransformToCss(ob);
        }
    }
}
