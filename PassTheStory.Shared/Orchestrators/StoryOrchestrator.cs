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
                IsEnd = part.IsEnd,
                StoryId = part.StoryId,
                StoryName = part.StoryName
            };

            var story = _storyContext.Stories.Find(part.StoryId);
            sp.Story = story;
            story.Parts.Add(sp);

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

            part.PartNumber = story.Parts.Count;
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
            var st = await _storyContext.Stories.ToListAsync();

            List<StoryViewModel> stories = new List<StoryViewModel>();

            foreach (Story s in st)
            {
                StoryViewModel svm = new StoryViewModel{ 
                    StoryId = s.StoryId,
                    StoryName = s.StoryName,
                    NextAuthor = s.NextAuthor,
                    IsFinished = s.IsFinished,
                    Parts = new List<StoryPartViewModel>()
                };
                

                foreach (StoryPart sp in s.Parts)
                {
                    StoryPartViewModel spvm = new StoryPartViewModel{
                        PartId = sp.PartId,
                        CreatedDateTime = sp.CreatedDateTime,
                        PartNumber = sp.PartNumber,
                        PartText = sp.PartText,
                        Author = sp.Author,
                        IsEnd = sp.IsEnd,
                        StoryId = sp.StoryId,
                        StoryName = sp.StoryName,
                        Story = svm
                    };
                    
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
                StoryViewModel svm = new StoryViewModel{ 
                    StoryId = s.StoryId,
                    StoryName = s.StoryName,
                    NextAuthor = s.NextAuthor,
                    IsFinished = s.IsFinished,
                    Parts = new List<StoryPartViewModel>()
                };

                foreach (StoryPart sp in s.Parts)
                {
                    StoryPartViewModel spvm = new StoryPartViewModel{
                        PartId = sp.PartId,
                        CreatedDateTime = sp.CreatedDateTime,
                        PartNumber = sp.PartNumber,
                        PartText = sp.PartText,
                        Author = sp.Author,
                        IsEnd = sp.IsEnd,
                        StoryId = sp.StoryId,
                        StoryName = sp.StoryName,
                        Story = svm
                    };
                    
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
                StoryViewModel svm = new StoryViewModel{ 
                    StoryId = s.StoryId,
                    StoryName = s.StoryName,
                    NextAuthor = s.NextAuthor,
                    IsFinished = s.IsFinished,
                    Parts = new List<StoryPartViewModel>()
                };

                foreach (StoryPart sp in s.Parts)
                {
                    StoryPartViewModel spvm = new StoryPartViewModel{
                        PartId = sp.PartId,
                        CreatedDateTime = sp.CreatedDateTime,
                        PartNumber = sp.PartNumber,
                        PartText = sp.PartText,
                        Author = sp.Author,
                        IsEnd = sp.IsEnd,
                        StoryId = sp.StoryId,
                        StoryName = sp.StoryName,
                        Story = svm
                    };
                    
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

            StoryViewModel storyView = new StoryViewModel{ 
                    StoryId = story.StoryId,
                    StoryName = story.StoryName,
                    NextAuthor = story.NextAuthor,
                    IsFinished = story.IsFinished,
                    Parts = new List<StoryPartViewModel>()
                };
            
            foreach (StoryPart sp in story.Parts)
                {
                    StoryPartViewModel spvm = new StoryPartViewModel{
                        PartId = sp.PartId,
                        CreatedDateTime = sp.CreatedDateTime,
                        PartNumber = sp.PartNumber,
                        PartText = sp.PartText,
                        Author = sp.Author,
                        IsEnd = sp.IsEnd,
                        StoryId = sp.StoryId,
                        StoryName = sp.StoryName,
                        Story = storyView
                    };
                    
                    storyView.Parts.Add(spvm);
                }
            
            return storyView;
        }
        public async Task<List<StoryViewModel>> GetMyContributions(string user)
        {
            var st = await _storyContext.Stories.ToListAsync();

            List<StoryViewModel> stories = new List<StoryViewModel>();

            foreach (Story s in st)
            {
                StoryViewModel svm = new StoryViewModel{ 
                    StoryId = s.StoryId,
                    StoryName = s.StoryName,
                    Parts = new List<StoryPartViewModel>()
                };

                foreach (StoryPart sp in s.Parts)
                {
                    StoryPartViewModel spvm = new StoryPartViewModel{
                        CreatedDateTime = sp.CreatedDateTime,
                        PartNumber = sp.PartNumber,
                        PartText = sp.PartText,
                        Author = sp.Author,
                        StoryId = sp.StoryId,
                        StoryName = sp.StoryName,
                        Story = svm
                    };
                    
                    if (spvm.Author == user)
                    {
                        svm.Parts.Add(spvm);
                    }
                    
                }
                if (svm.Parts.Count > 0)
                {
                    stories.Add(svm);
                }
            }

            if (stories == null)
            {
                return new List<StoryViewModel>();
            }

            return stories;
        }

        public async Task<StoryViewModel> GetFinishedTopicStory(string keyword)
        {
            var story = await _storyContext.StoryParts
                .Where(x => x.Story.IsFinished == true
                    && (x.StoryName.Contains(keyword) 
                    || x.PartText.Contains(keyword)))
                .OrderBy(c => Guid.NewGuid())
                .FirstOrDefaultAsync();

            if (story == null)
            {
                return new StoryViewModel();
            }

            StoryViewModel storyView = new StoryViewModel{ 
                    StoryId = story.StoryId,
                    StoryName = story.StoryName,
                    NextAuthor = story.Story.NextAuthor,
                    IsFinished = story.Story.IsFinished,
                    Parts = new List<StoryPartViewModel>()
                };
            
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

        public async Task<List<StoryViewModel>> GetMyNextStories(string user)
        {
            var st = await _storyContext.Stories
                .Where(x => x.NextAuthor == user)
                .ToListAsync();

            if (st == null)
            {
                return new List<StoryViewModel>();
            }

            List<StoryViewModel> stories = new List<StoryViewModel>();

            foreach (Story s in st)
            {
                StoryViewModel svm = new StoryViewModel{ 
                    StoryId = s.StoryId,
                    StoryName = s.StoryName,
                    Parts = new List<StoryPartViewModel>()
                };

                foreach (StoryPart sp in s.Parts)
                {
                    StoryPartViewModel spvm = new StoryPartViewModel{
                        CreatedDateTime = sp.CreatedDateTime,
                        PartNumber = sp.PartNumber,
                        PartText = sp.PartText,
                        Author = sp.Author,
                        StoryId = sp.StoryId,
                        StoryName = sp.StoryName,
                        Story = svm
                    };
                        svm.Parts.Add(spvm);
                }
                    stories.Add(svm);
            }

            return stories;
        }
    }
}