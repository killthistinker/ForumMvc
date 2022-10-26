using System;
using ForumMvc.Models;
using ForumMvc.ViewModels;

namespace ForumMvc.Helpers
{
    public static class TopicCreateMapper
    {
        public static Topic MapToTopic(this TopicViewModel self)
        {
            Topic topic = new Topic
            {
                Title = self.Title,
                Description = self.Description,
                UserId = self.UserId,
                DateCreate = DateTime.Now
            };
            return topic;
        }
    }
}