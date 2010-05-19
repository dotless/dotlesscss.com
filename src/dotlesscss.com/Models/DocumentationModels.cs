
using System.Collections.Generic;
using dotlesscss.com.Documentation;

namespace dotlesscss.com.Models
{
  /*
   *  Should probably use AutoMapper, but it's just as quick to write it like this for now :)
   */
  public class ChapterModel : Chapter
  {
    public ChapterModel(Chapter chapter)
    {
      Description = chapter.Description.Trim();
      Name = chapter.Name.Trim();
      SortOrder = chapter.SortOrder;
      Topics = chapter.Topics;
    }
  }

  public class TopicModel : Topic
  {
    public List<Chapter> All { get; set; }
    public string ExampleResult { get; set; }
    public string ExampleCss { get; set; }

    public TopicModel()
    { }

    public TopicModel(Topic topic)
    {
      Description = topic.Description.Trim();
      FurtherDescription = topic.FurtherDescription.Trim();
      SeeAlso = topic.SeeAlso;
      ExampleBody = topic.ExampleBody.Trim();
      ExampleLess = topic.ExampleLess.Trim();
      Name = topic.Name.Trim();
      SortOrder = topic.SortOrder;
      Parameters = topic.Parameters.Trim();
    }
  }
}
