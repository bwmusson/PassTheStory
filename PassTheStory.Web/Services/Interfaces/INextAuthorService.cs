using System;
using System.Threading.Tasks;
using PassTheStory.Web.Models;

namespace PassTheStory.Web.Services.Interfaces
{
    public interface INextAuthorService
    {
        Task<string> GetNextAuthor(ApplicationUser lastAuthor);
    }
}