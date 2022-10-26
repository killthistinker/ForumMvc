using System;
using System.Linq;
using ForumMvc.Models;
using ForumMvc.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ForumMvc.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly ForumContext _context;

        public AnswerService(ForumContext context)
        {
            _context = context;
        }

        public void AddAnswer(int userId, int postId, string description)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user is null) return ;
            var post = _context.Topics.Include(p => p.Answers).FirstOrDefault(p => p.Id == postId);
            if(post is null) return ;
            Answer answer = new Answer
            {
                Description = description,
                User = user,
                Topic = post,
                TopicId = post.Id,
                UserId = user.Id,
                DateOfCreate = DateTime.Now
            };
            _context.Answers.Add(answer);
            _context.Topics.Update(post);
            _context.SaveChanges();
        }

        public IOrderedQueryable<Answer> GetAnswers(int postId)
        {
            var answers = _context.Answers
                .Include(a => a.Topic)
                .Include(a => a.User)
                .Where(a => a.TopicId == postId).OrderByDescending(u => u.DateOfCreate);
            return answers;
        }
    }
}