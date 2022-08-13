using System;
using exam8.Models;
using exam8.ViewModels;

namespace exam8.Helpers
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