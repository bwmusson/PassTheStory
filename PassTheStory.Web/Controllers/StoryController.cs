using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PassTheStory.Shared.Orchestrators.Interfaces;
using PassTheStory.Shared.ViewModels;
using PassTheStory.Web.Models;
using PassTheStory.Web.Services.Interfaces;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PassTheStory.Web.Controllers
{
    public class StoryController : Controller
    {
        private readonly IStoryOrchestrator _storyOrchestrator;
        private readonly INextAuthorService _nextAuthorService;

        public StoryController(IStoryOrchestrator storyOrchestrator, INextAuthorService nextAuthorService)
        {
            _storyOrchestrator = storyOrchestrator;
            _nextAuthorService = nextAuthorService;
        }

        // GET: Story
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetAllStories()
        {
            var storyDisplayModel = new StoryDisplayModel()
            {
                Stories = await _storyOrchestrator.GetAllStories()
            };
            return View(storyDisplayModel);
        }

        public async Task<ActionResult> GetFinishedStories()
        {
            var storyDisplayModel = new StoryDisplayModel()
            {
                Stories = await _storyOrchestrator.GetFinishedStories()
            };
            return View(storyDisplayModel);
        }
        public async Task<ActionResult> GetNewPrompts()
        {
            var storyDisplayModel = new StoryDisplayModel()
            {
                Stories = await _storyOrchestrator.GetNewPrompts()
            };
            return View(storyDisplayModel);
        }

        public async Task<ActionResult> ViewStory(Guid id)
        {
            StoryViewModel story = await _storyOrchestrator.GetStory(id);
            if (story.StoryId == Guid.Empty)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePrompt(StoryPartModel prompt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _storyOrchestrator.CreatePrompt(new StoryPartViewModel
                    {
                        PartId = Guid.NewGuid(),
                        CreatedDateTime = DateTime.Now,
                        PartText = prompt.PartText,
                        Author = prompt.Author.UserName,
                        IsEnd = prompt.IsEnd,
                        StoryId = Guid.NewGuid(),
                        StoryName = prompt.StoryName
                    });

                    System.Web.HttpContext.Current.Response.Write("<script>alert('Prompt created successfully!')</script>");
                    ModelState.Clear();
                    return View();
                }
                catch (DataException dex)
                {
                    Console.WriteLine(dex);
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            return View();
        }

        public async Task<ActionResult> Pass(StoryModel story)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            string nextAuthor = await _nextAuthorService.GetNextAuthor(user);

            while (nextAuthor == user.UserName || 
                (story.Parts.Count <= 2 && nextAuthor == story.Parts[0].Author.UserName))
            {
                nextAuthor = await _nextAuthorService.GetNextAuthor(user);
            }

            await _nextAuthorService.SetNextAuthor(story.StoryId, nextAuthor);

            return View();
        }
        public async Task<ActionResult> AddPart(StoryPartModel part)
        {
            //Only NextAuthor (if/then)
            await _storyOrchestrator.AddPart(new StoryPartViewModel
            {
                PartId = Guid.NewGuid(),
                CreatedDateTime = DateTime.Now,
                PartText = part.PartText,
                Author = part.Author.UserName,
                IsEnd = part.IsEnd,
                StoryId = part.StoryId,
                StoryName = part.StoryName
            });

            if (part.IsEnd == false){
                var nextAuthor = await _nextAuthorService.GetNextAuthor(part.Author);
                await _nextAuthorService.SetNextAuthor(part.StoryId, nextAuthor);
            }
            else
            {
                await _storyOrchestrator.FinishStory(part.StoryId);
            }

            return View();
        }
    }
}