using PassTheStory.Domain.Entities;
using System.Data.Entity;

namespace PassTheStory.Domain
{
    public class StoryContext : DbContext
    {
        public DbSet<Story> Stories { get; set; }
        public DbSet<StoryPart> StoryParts { get; set; }
    }
}