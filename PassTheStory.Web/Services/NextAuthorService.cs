using PassTheStory.Shared.Orchestrators.Interfaces;
using PassTheStory.Web.Models;
using PassTheStory.Web.Services.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PassTheStory.Web.Services
{
    public class NextAuthorService : INextAuthorService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IStoryOrchestrator _storyOrchestrator;
        
        public NextAuthorService(ApplicationDbContext applicationDbContext, IStoryOrchestrator storyOrchestrator)
        {
            _applicationDbContext = applicationDbContext;
            _storyOrchestrator = storyOrchestrator;
        }

        public async Task<string> GetNextAuthor(ApplicationUser lastAuthor)
        {
            ApplicationUser nextAuthor = lastAuthor;
            while (nextAuthor.Equals(lastAuthor))
            {
                nextAuthor = await _applicationDbContext.Users
                    .OrderBy(c => Guid.NewGuid())
                    .FirstOrDefaultAsync();
            }

            return nextAuthor.UserName;
        }
        public async Task<int> SetNextAuthor(Guid storyId, string nextAuthor)
        {
            return await _storyOrchestrator.SetNextAuthor(storyId, nextAuthor);
        }
    }
}