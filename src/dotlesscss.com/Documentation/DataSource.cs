using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Serialization;

namespace dotlesscss.com.Documentation
{
  [XmlRoot("chapter")]
  public class Chapter
  {
    [XmlAttribute("name")]
    public string Name { get; set; }

    [XmlAttribute("order")]
    public int SortOrder { get; set; }

    [XmlElement("description")]
    public string Description { get; set; }

    [XmlElement(Type = typeof(Topic), ElementName = "topic")]
    public List<Topic> Topics;
  }

  public class Topic
  {
    [XmlAttribute("name")]
    public string Name { get; set; }

    [XmlAttribute("order")]
    public int SortOrder { get; set; }

    [XmlElement("params")]
    public string Parameters;

    [XmlElement("description")]
    public string Description { get; set; }

    [XmlElement("further")]
    public string FurtherDescription { get; set; }

    [XmlElement("seealso")]
    public string SeeAlso { get; set; }

    [XmlElement("exampleLess")]
    public string ExampleLess { get; set; }

    [XmlElement("exampleBody")]
    public string ExampleBody { get; set; }
  }

  public class DataSource
  {
    public static List<Chapter> Chapters { get; private set; }

    static DataSource()
    {
      LoadChaptersByReflection();
    }

    public static void LoadChaptersByReflection()
    {
      Assembly asm = Assembly.GetExecutingAssembly();
      Chapters = new List<Chapter>();

      foreach (string resourceName in Assembly.GetExecutingAssembly().GetManifestResourceNames())
      {
        if (!Regex.IsMatch(resourceName, @"Documentation.*\.xml$", RegexOptions.IgnoreCase))
          continue;

        XmlSerializer ser = new XmlSerializer(typeof(Chapter));
        Chapters.Add((Chapter)ser.Deserialize(asm.GetManifestResourceStream(resourceName)));
      }

      Chapters.Sort((x, y) => x.SortOrder - y.SortOrder);
      Chapters.ForEach(chapter => chapter.Topics.Sort((x, y) => x.SortOrder - y.SortOrder));
    }

    public static Chapter FindChapter(string chapterName)
    {
      return string.IsNullOrEmpty(chapterName)
          ? null
          : Chapters.FirstOrDefault(chapter => string.Compare(chapter.Name, chapterName, StringComparison.OrdinalIgnoreCase) == 0);
    }

    public static Topic FindTopic(Chapter chapter, string topicName)
    {
      return string.IsNullOrEmpty(topicName)
          ? null
          : chapter.Topics.FirstOrDefault(topic => string.Compare(topic.Name, topicName, StringComparison.OrdinalIgnoreCase) == 0);
    }
  }
}
