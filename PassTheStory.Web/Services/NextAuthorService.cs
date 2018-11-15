using System;
using System.Linq;
using System.Threading.Tasks;
using PassTheStory.Web.Services.Interfaces;
using PassTheStory.Web.Models;

namespace PassTheStory.Web.Services
{
    public class NextAuthorService : INextAuthorService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public async Task<string> GetNextAuthor(ApplicationUser lastAuthor)
        {
            ApplicationUser nextAuthor = lastAuthor;
            while (nextAuthor.Equals(lastAuthor))
            {
                nextAuthor = _applicationDbContext.Users
                    .OrderBy(c => Guid.NewGuid())
                    .FirstOrDefault();
            }

            return nextAuthor.UserName;
        }
    }
}