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

        public async Task<ActionResult> AllStories()
        {
            var storyDisplayModel = new StoryDisplayModel()
            {
                Stories = await _storyOrchestrator.GetAllStories()
            };
            return View(storyDisplayModel);
        }

        public async Task<ActionResult> MyContributions()
        {
            var user = System.Web.HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            var storyDisplayModel = new StoryDisplayModel()
            {
                Stories = await _storyOrchestrator.GetMyContributions(user.UserName)
            };
            return View(storyDisplayModel);
        }

        public async Task<ActionResult> MyNextStories()
        {
            var user = System.Web.HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            var storyDisplayModel = new StoryDisplayModel()
            {
                Stories = await _storyOrchestrator.GetMyNextStories(user.UserName)
            };
            return View(storyDisplayModel);
        }

        public async Task<ActionResult> FinishedStories()
        {
            var storyDisplayModel = new StoryDisplayModel()
            {
                Stories = await _storyOrchestrator.GetFinishedStories()
            };
            return View(storyDisplayModel);
        }
        public async Task<ActionResult> NewPrompts()
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
            ViewBag.Message = story.StoryId;
            return View(story);
        }

        public ActionResult CreatePrompt()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreatePrompt(StoryPartModel prompt)
        {
            var user = System.Web.HttpContext.Current.GetOwinContext()
                            .GetUserManager<ApplicationUserManager>()
                            .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            if (ModelState.IsValid)
            {
                try
                {
                    var part = new StoryPartViewModel
                    {
                        PartId = Guid.NewGuid(),
                        CreatedDateTime = DateTime.Now,
                        PartText = prompt.PartText,
                        Author = user.UserName,
                        IsEnd = false,
                        StoryId = Guid.NewGuid(),
                        StoryName = prompt.StoryName
                    };

                    await _storyOrchestrator.CreatePrompt(part);
                    
                    var nextAuthor = await _nextAuthorService.GetNextAuthor(user);
                    await _nextAuthorService.SetNextAuthor(part.StoryId, nextAuthor);

                    System.Web.HttpContext.Current.Response.Write("<script>alert('Prompt created successfully!')</script>");
                    ModelState.Clear();
                    return View("CreatePrompt");
                }
                catch (DataException dex)
                {
                    Console.WriteLine(dex);
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            return View("CreatePrompt");
        }

        public async Task<ActionResult> Pass(StoryModel story)
        {
            var user = System.Web.HttpContext.Current.GetOwinContext()
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
        public ActionResult AddPart(Guid story)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddPart(StoryPartModel part)
        {
            var user = System.Web.HttpContext.Current.GetOwinContext()
                            .GetUserManager<ApplicationUserManager>()
                            .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            if (ModelState.IsValid)
            {
                try
                {
                    var sp = new StoryPartViewModel
                    {
                        PartId = Guid.NewGuid(),
                        CreatedDateTime = DateTime.Now,
                        PartText = part.PartText,
                        Author = user.UserName,
                        IsEnd = part.IsEnd,
                        StoryId = ViewBag.Id
                    };


                    await _storyOrchestrator.AddPart(sp);

                    if (part.IsEnd == false)
                    {
                        var nextAuthor = await _nextAuthorService.GetNextAuthor(user);
                        await _nextAuthorService.SetNextAuthor(part.StoryId, nextAuthor);
                    }
                    else
                    {
                        await _storyOrchestrator.FinishStory(part.StoryId);
                    }
                    return View("Index");
                
                }
                catch (DataException dex)
                {
                Console.WriteLine(dex);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            return View("AddPart");
        }
    }
}