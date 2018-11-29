using PassTheStory.Web.Models;

namespace PassTheStory.Web.Services.Interfaces
{
    public interface INextAuthorService
    {
        string GetNextAuthor(ApplicationUser lastAuthor);
    }
}