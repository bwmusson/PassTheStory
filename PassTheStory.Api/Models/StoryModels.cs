using System;

namespace PassTheStory.Api.Models
{
    public class Story
    {
        public string StoryName { get; set; }
        public string Text { get; set; }
    }
    public class StoryPart
    {
        public Guid PartId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int PartNumber { get; set; }
        public string PartText { get; set; }
        public string Author { get; set; }
        public Boolean IsEnd { get; set; }
    }
}