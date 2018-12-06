using PassTheStory.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PassTheStory.Web.Models
{
    public class StoryModel
    {
        [Key]
        public Guid StoryId { get; set; }
        public string StoryName { get; set; }
        public virtual IList<StoryPartModel> Parts { get; set; }
        public string NextAuthor { get; set; }
        public Boolean isFinished { get; set; }
    }
    public class StoryPartModel
    {
        [Key]
        public Guid PartId { get; set; }
        public DateTime CreatedTime { get; set; }
        public int PartNumber { get; set; }
        [Required]
        [MaxLength(1000)]
        [Display(Name = "Part Text")]
        public string PartText { get; set; }
        public ApplicationUser Author { get; set; }
        [Required]
        public Boolean IsEnd { get; set; }
        public Guid StoryId { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Story Name")]
        public string StoryName { get; set; }
    }

    public class StoryDisplayModel
    {
        public IList<StoryViewModel> Stories { get; set; }
    }
}