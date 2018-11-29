using PassTheStory.Web.Models;
using PassTheStory.Web.Services.Interfaces;
using System;
using System.Linq;

namespace PassTheStory.Web.Services
{
    public class NextAuthorService : INextAuthorService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        
        public NextAuthorService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public string GetNextAuthor(ApplicationUser lastAuthor)
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