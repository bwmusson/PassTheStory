using PassTheStory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassTheStory.Shared.ViewModels
{
    public class StoryViewModel
    {
        public Guid StoryId { get; set; }
        public string StoryName { get; set; }
        public virtual IList<StoryPartViewModel> Parts { get; set; }
        public string NextAuthor { get; set; }
        public Boolean IsFinished { get; set; }

    }
    public class StoryPartViewModel
    {
        public Guid PartId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int PartNumber { get; set; }
        public string PartText { get; set; }
        public string Author { get; set; }
        public Boolean IsEnd { get; set; }
        public Guid StoryId { get; set; }
        public string StoryName { get; set; }
        public virtual StoryViewModel Story { get; set; }
    }
}