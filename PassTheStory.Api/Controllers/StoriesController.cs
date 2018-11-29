using PassTheStory.Api.Models;
using PassTheStory.Shared.Orchestrators;
using PassTheStory.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace PassTheStory.Api.Controllers
{
    public class StoriesController : ApiController
    {
        private readonly StoryOrchestrator _storyOrchestrator = new StoryOrchestrator();

        public StoriesController()
        {
            _storyOrchestrator = new StoryOrchestrator();
        }

        // GET: api/Stories
        public async Task<IList<Story>> GetAllFinishedStories()
        {
            IList<StoryViewModel> finished = await _storyOrchestrator.GetFinishedStories();

            IList<Story> stories = new List<Story>();

            foreach (StoryViewModel s in finished)
            {
                string text = "";

                foreach (StoryPartViewModel p in s.Parts)
                {
                    text += p.PartText + "\n\n - Contributed by user " + p.Author + " on " + p.CreatedDateTime.ToShortDateString() + ".\n\n";
                };
                text += "THE END";

                Story story = new Story
                {
                    StoryName = s.StoryName,
                    Text = text
                };
                
                stories.Add(story);
            };

            return stories;
        }

        // GET: api/Stories/5
        public async Task<IHttpActionResult> GetFinishedTopicStory(string keyword)
        {
            keyword = keyword.Trim();

            StoryViewModel random = await _storyOrchestrator.GetFinishedTopicStory(keyword);

            if (random.StoryId == Guid.Empty)
            {
                return Content(HttpStatusCode.NotFound, "Error 404: No Stories Found Containing Given Word");
            }

            else
            {

            string text = "";
            
            foreach (StoryPartViewModel p in random.Parts)
            {
                text += p.PartText + "\n\n - Contributed by user " + p.Author + " on " + p.CreatedDateTime.ToShortDateString() + ".\n\n";
            };

            text += "THE END";

            Story story = new Story
            {
                StoryName = random.StoryName,
                Text = text
            };

            return Ok(story);

            }
        }
    }
}
