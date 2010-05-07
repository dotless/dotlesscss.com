
using System.Collections.Generic;
using dotlesscss.com.Documentation;

namespace dotlesscss.com.Models
{
    /*
     *  Should probably use AutoMapper, but it's just as quick to write it like this for now :)
     */ 
    public class ChapterModel : Documentation.Chapter
    {
        public ChapterModel(Documentation.Chapter chapter)
        {
            this.Description = chapter.Description;
            this.Name = chapter.Name;
            this.SortOrder = chapter.SortOrder;
            this.Topics = chapter.Topics;
        }
    }

    public class TopicModel : Documentation.Topic
    {
    	public List<Chapter> All { get; set;}
        public string ExampleResult { get; set; }
        public string ExampleCss { get; set; }

        public TopicModel()
        { }

        public TopicModel(Documentation.Topic topic)
        {
            this.Description = topic.Description;
            this.FurtherDescription = topic.FurtherDescription;
        	this.SeeAlso = topic.SeeAlso;
            this.ExampleBody = topic.ExampleBody;
            this.ExampleLess = topic.ExampleLess;
            this.Name = topic.Name;
            this.SortOrder = topic.SortOrder;
            this.Parameters = new List<Param>();
            this.Parameters.AddRange(topic.Parameters);
        }
    }
}
