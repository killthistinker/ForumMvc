using System.Collections.Generic;
using exam8.Models;
using exam8.ViewModels;

namespace exam8.Services.Abstractions
{
    public interface ITopicService
    {
        public void CreateTopic(TopicViewModel model);
        public IEnumerable<Topic> GetTopics();
        public Topic GetTopic(int id);
    }
}