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
            //part.StoryName = story.StoryName;
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
            var st = await _storyContext.Stories.ToListAsync();

            List<StoryViewModel> stories = new List<StoryViewModel>();

            foreach (Story s in st)
            {
                StoryViewModel svm = new StoryViewModel();
                svm.StoryId = s.StoryId;
                svm.StoryName = s.StoryName;
                svm.NextAuthor = s.NextAuthor;
                svm.IsFinished = s.IsFinished;

                foreach (StoryPart sp in s.Parts)
                {
                    StoryPartViewModel spvm = new StoryPartViewModel();
                    
                    spvm.PartId = sp.PartId;
                    spvm.CreatedDateTime = sp.CreatedDateTime;
                    spvm.PartNumber = sp.PartNumber;
                    spvm.PartText = sp.PartText;
                    spvm.Author = sp.Author;
                    spvm.IsEnd = sp.IsEnd;
                    spvm.StoryId = sp.StoryId;
                    spvm.StoryName = sp.StoryName;
                    spvm.Story = svm;
                    
                    svm.Parts.Add(spvm);
                }

                stories.Add(svm);
            }

            return stories;
        }

        public async Task<List<StoryViewModel>> GetFinishedStories()
        {
            List<Story> st = await _storyContext.Stories
                .Where(x => x.IsFinished == true).ToListAsync();

            List<StoryViewModel> stories = new List<StoryViewModel>();

            foreach (Story s in st)
            {
                StoryViewModel svm = new StoryViewModel();
                svm.StoryId = s.StoryId;
                svm.StoryName = s.StoryName;
                svm.NextAuthor = s.NextAuthor;
                svm.IsFinished = s.IsFinished;

                foreach (StoryPart sp in s.Parts)
                {
                    StoryPartViewModel spvm = new StoryPartViewModel();
                    
                    spvm.PartId = sp.PartId;
                    spvm.CreatedDateTime = sp.CreatedDateTime;
                    spvm.PartNumber = sp.PartNumber;
                    spvm.PartText = sp.PartText;
                    spvm.Author = sp.Author;
                    spvm.IsEnd = sp.IsEnd;
                    spvm.StoryId = sp.StoryId;
                    spvm.StoryName = sp.StoryName;
                    spvm.Story = svm;
                    
                    svm.Parts.Add(spvm);
                }

                stories.Add(svm);
            }

            return stories;
        }

        public async Task<List<StoryViewModel>> GetNewPrompts()
        {
            var st = await _storyContext.Stories
                .Where(x => x.Parts.Count == 1)
                .ToListAsync();

            List<StoryViewModel> stories = new List<StoryViewModel>();

            foreach (Story s in st)
            {
                StoryViewModel svm = new StoryViewModel();
                svm.StoryId = s.StoryId;
                svm.StoryName = s.StoryName;
                svm.NextAuthor = s.NextAuthor;
                svm.IsFinished = s.IsFinished;

                foreach (StoryPart sp in s.Parts)
                {
                    StoryPartViewModel spvm = new StoryPartViewModel();
                    
                    spvm.PartId = sp.PartId;
                    spvm.CreatedDateTime = sp.CreatedDateTime;
                    spvm.PartNumber = sp.PartNumber;
                    spvm.PartText = sp.PartText;
                    spvm.Author = sp.Author;
                    spvm.IsEnd = sp.IsEnd;
                    spvm.StoryId = sp.StoryId;
                    spvm.StoryName = sp.StoryName;
                    spvm.Story = svm;
                    
                    svm.Parts.Add(spvm);
                }

                stories.Add(svm);
            }

            return stories;
        }

        public async Task<StoryViewModel> GetStory(Guid id)
        {
            var story = await _storyContext.Stories
                .FindAsync(id);

            if (story == null)
            {
                return new StoryViewModel();
            }

            StoryViewModel storyView = new StoryViewModel();

            storyView.StoryId = story.StoryId;
            storyView.StoryName = story.StoryName;
            storyView.NextAuthor = story.NextAuthor;
            storyView.IsFinished = story.IsFinished;
            
            foreach (StoryPart sp in story.Parts)
                {
                    StoryPartViewModel spvm = new StoryPartViewModel();
                    
                    spvm.PartId = sp.PartId;
                    spvm.CreatedDateTime = sp.CreatedDateTime;
                    spvm.PartNumber = sp.PartNumber;
                    spvm.PartText = sp.PartText;
                    spvm.Author = sp.Author;
                    spvm.IsEnd = sp.IsEnd;
                    spvm.StoryId = sp.StoryId;
                    spvm.StoryName = sp.StoryName;
                    spvm.Story = storyView;
                    
                    storyView.Parts.Add(spvm);
                }
            
            return storyView;
        }

        public async Task<StoryViewModel> GetFinishedTopicStory(string keyword)
        {
            var story = await _storyContext.StoryParts
                .Where(x => x.Story.IsFinished == true
                    && (x.StoryName.Contains(keyword) 
                    || x.PartText.Contains(keyword)))
                .OrderBy(c => Guid.NewGuid())
                .FirstOrDefaultAsync();

            StoryViewModel storyView = new StoryViewModel();

            storyView.StoryId = story.StoryId;
            storyView.StoryName = story.StoryName;
            storyView.NextAuthor = story.Story.NextAuthor;
            storyView.IsFinished = story.Story.IsFinished;
            
            foreach (StoryPart sp in story.Story.Parts)
                {
                    StoryPartViewModel spvm = new StoryPartViewModel();
                    
                    spvm.PartId = sp.PartId;
                    spvm.CreatedDateTime = sp.CreatedDateTime;
                    spvm.PartNumber = sp.PartNumber;
                    spvm.PartText = sp.PartText;
                    spvm.Author = sp.Author;
                    spvm.IsEnd = sp.IsEnd;
                    spvm.StoryId = sp.StoryId;
                    spvm.StoryName = sp.StoryName;
                    spvm.Story = storyView;
                    
                    storyView.Parts.Add(spvm);
                }

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