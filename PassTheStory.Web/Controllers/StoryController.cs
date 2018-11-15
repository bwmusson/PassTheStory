﻿using PassTheStory.Shared.Orchestrators.Interfaces;
using PassTheStory.Shared.ViewModels;
using PassTheStory.Web.Models;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Web.Mvc;
using PassTheStory.Web.Services;
using PassTheStory.Web.Services.Interfaces;

namespace PassTheStory.Web.Controllers
{
    public class StoryController : Controller
    {
        private readonly IStoryOrchestrator _storyOrchestrator;
        private readonly INextAuthorService _nextAuthorService = new NextAuthorService();

        public StoryController(IStoryOrchestrator storyOrchestrator)
        {
            _storyOrchestrator = storyOrchestrator;
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
        public async Task<ActionResult> AddPart(StoryPartModel part)
        {
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

            var nextAuthor = await _nextAuthorService.GetNextAuthor(part.Author);
            await _storyOrchestrator.SetNextAuthor(part.StoryId, nextAuthor);


            return View();
        }
    }
}