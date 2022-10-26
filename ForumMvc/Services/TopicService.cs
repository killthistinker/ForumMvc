using System.Collections.Generic;
using System.Linq;
using ForumMvc.Helpers;
using ForumMvc.Models;
using ForumMvc.Services.Abstractions;
using ForumMvc.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ForumMvc.Services
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