
using System;
using System.Collections.Generic;
using System.Linq;
using dotlesscss.com.Documentation;

namespace dotlesscss.com.Models
{
  /*
   *  Should probably use AutoMapper, but it's just as quick to write it like this for now :)
   */
  public class ChapterModel
  {
    public string Name { get; set; }
    public int SortOrder { get; set; }
    public List<TopicModel> Topics { get; set; }

    public ChapterModel(Chapter chapter)
    {
      Name = chapter.Name.Trim();
      SortOrder = chapter.SortOrder;
      Topics = TopicModel.FromTopicList(chapter.Topics);
    }

    public static List<ChapterModel> FromChaperList(IEnumerable<Chapter> chapters)
    {
      return chapters.Select(c => new ChapterModel(c)).ToList();
    }
  }

  public class TopicModel
  {
    public List<ChapterModel> All { get; set; }
    public string ExampleResult { get; set; }
    public string ExampleCss { get; set; }

    public string Description { get; set; }
    public string FurtherDescription { get; set; }
    public string ExampleBody { get; set; }
    public string ExampleLess { get; set; }
    public string Name { get; set; }
    public string Parameters { get; set; }

    public TopicModel()
    { }

    public TopicModel(Topic topic)
    {
      Description = topic.Description.Trim();
      FurtherDescription = topic.FurtherDescription.Trim();
      ExampleBody = topic.ExampleBody.Trim();
      ExampleLess = topic.ExampleLess.Trim();
      Name = topic.Name.Trim();
      Parameters = topic.Parameters.Trim();
    }

    public static List<TopicModel> FromTopicList(IEnumerable<Topic> topics)
    {
      return topics.Select(t => new TopicModel(t)).ToList();
    }
  }
}
