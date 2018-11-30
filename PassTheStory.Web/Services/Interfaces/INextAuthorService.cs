using PassTheStory.Web.Models;
using System;
using System.Threading.Tasks;

namespace PassTheStory.Web.Services.Interfaces
{
    public interface INextAuthorService
    {
        Task<string> GetNextAuthor(ApplicationUser lastAuthor);
        Task<int> SetNextAuthor(Guid storyId, string nextAuthor);
    }
}