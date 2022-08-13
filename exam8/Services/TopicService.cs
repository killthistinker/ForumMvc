using System.Collections.Generic;
using System.Linq;
using exam8.Helpers;
using exam8.Models;
using exam8.Services.Abstractions;
using exam8.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace exam8.Services
{
    public class TopicService : ITopicService
    {
        private readonly ForumContext _context;

        public TopicService(ForumContext context)
        {
            _context = context;
        }

        public void CreateTopic(TopicViewModel model)
        {
            Topic topic = model.MapToTopic();
            if (topic != null)
            {
               _context.Topics.Add(topic); 
               _context.SaveChanges();
            }
        }

        public IEnumerable<Topic> GetTopics()
        {
            var topics = _context.Topics.Include(t => t.User).Include(t => t.Answers).AsEnumerable();
            return topics;
        }

        public Topic GetTopic(int id)
        {
            Topic topic = _context.Topics
                .Include(t => t.User)
                .Include(t => t.Answers.OrderByDescending(a => a.DateOfCreate))
                .ThenInclude(t => t.User)
                .FirstOrDefault(t => t.Id == id);
            return topic;

        }
    }
}