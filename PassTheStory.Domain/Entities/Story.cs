using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PassTheStory.Domain.Entities
{
    public class Story
    {
        [Key]
        public Guid StoryId { get; set; }
        public string StoryName { get; set; }
        public virtual IList<StoryPart> Parts { get; set; }
        public string NextAuthor { get; set; }
        public Boolean IsFinished { get; set; }
    }
}