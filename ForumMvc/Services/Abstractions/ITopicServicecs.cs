using System.Collections.Generic;
using ForumMvc.Models;
using ForumMvc.ViewModels;

namespace ForumMvc.Services.Abstractions
{
    public interface ITopicService
    {
        public void CreateTopic(TopicViewModel model);
        public IEnumerable<Topic> GetTopics();
        public Topic GetTopic(int id);
    }
}