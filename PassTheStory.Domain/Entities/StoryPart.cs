﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassTheStory.Domain.Entities
{
    public class StoryPart
    {
        [Key]
        public Guid PartId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int PartNumber { get; set; }
        [Required]
        [MaxLength(5000)]
        public string PartText { get; set; }
        public string Author { get; set; }
        [Required]
        public Boolean IsEnd { get; set; }
        [ForeignKey("Story")]
        public Guid StoryId { get; set; }
        [MaxLength(100)]
        public string StoryName { get; set; }
        public virtual Story Story { get; set; }
    }
}