using PassTheStory.Domain;
using PassTheStory.Domain.Entities;
using PassTheStory.Shared.Orchestrators.Interfaces;
using PassTheStory.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PassTheStory.Shared.Orchestrators
{
    public class StoryOrchestrator : IStoryOrchestrator
    {
        private readonly StoryContext _storyContext;

        public StoryOrchestrator()
        {
            _storyContext = new StoryContext();
        }


        public async Task<int> AddPart(StoryPartViewModel part)
        {
            var sp = new StoryPart
            {
                PartId = Guid.NewGuid(),
                CreatedDateTime = DateTime.Now,
                PartText = part.PartText,
                Author = part.Author,
                IsEnd = part.IsEnd
            };


            _storyContext.StoryParts.Add(sp);

            return await _storyContext.SaveChangesAsync();
        }

        public async Task<int> CreatePrompt(StoryPartViewModel prompt)
        {
            var story = new Story
            {
                StoryId = prompt.StoryId,
                StoryName = prompt.StoryName
            };
            var part = new StoryPart
            {
                PartId = prompt.PartId,
                CreatedDateTime = DateTime.Now,
                PartText = prompt.PartText,
                Author = prompt.Author,
                IsEnd = false,
                StoryId = prompt.StoryId
            };
            
            _storyContext.Stories.Add(story);

            await _storyContext.SaveChangesAsync();

            story.Parts.Add(part);

            part.PartNumber = story.Parts.IndexOf(part);
            part.StoryName = story.StoryName;
            part.Story = story;

            _storyContext.StoryParts.Add(part);

            return await _storyContext.SaveChangesAsync();
        }

        public async Task<int> FinishStory(Guid storyId)
        {
            var story = _storyContext.Stories.Find(storyId);
            story.IsFinished = true;
            return await _storyContext.SaveChangesAsync();
        }

        public async Task<List<StoryViewModel>> GetAllStories()
        {
            var stories = await _storyContext.Stories.Select(x => new StoryViewModel
            {
                StoryId = x.StoryId,
                StoryName = x.StoryName,
                Parts = x.Parts
            }).ToListAsync();

            return stories;
        }

        public async Task<List<StoryViewModel>> GetFinishedStories()
        {
            var stories = _storyContext.Stories.Where(x => x.IsFinished == true);

            return (List<StoryViewModel>)stories;
        }

        public async Task<List<StoryViewModel>> GetNewPrompts()
        {
            var stories = _storyContext.Stories.Where(x => x.Parts.Count == 1);

            return (List<StoryViewModel>)stories;
        }

        public async Task<StoryViewModel> GetStory(Guid id)
        {
            var story = _storyContext.Stories.Find(id);
            if (story == null)
            {
                return new StoryViewModel();
            }

            var storyView = new StoryViewModel
            {
                StoryId = story.StoryId,
                StoryName = story.StoryName,
                Parts = story.Parts
            };

            return storyView;
        }

        public async Task<int> SetNextAuthor(Guid storyId, string nextAuthor)
        {
            var story = _storyContext.Stories.Find(storyId);
            story.NextAuthor = nextAuthor;
            return await _storyContext.SaveChangesAsync();
        }
    }
}