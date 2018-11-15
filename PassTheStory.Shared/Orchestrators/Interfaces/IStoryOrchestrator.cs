﻿using PassTheStory.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PassTheStory.Shared.Orchestrators.Interfaces
{
    public interface IStoryOrchestrator
    {
        Task<List<StoryViewModel>> GetAllStories();
        Task<int> CreatePrompt(StoryPartViewModel prompt);
        Task<int> AddPart(StoryPartViewModel part);
        Task<StoryViewModel> GetStory(Guid id);
        Task<int> SetNextAuthor(Guid storyId, string nextAuthor);


    }
}