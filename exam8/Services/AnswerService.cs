using System;
using System.Collections.Generic;
using System.Linq;
using exam8.Models;
using exam8.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace exam8.Services
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

        public List<Answer> GetAnswers(int postId)
        {
            var answers = _context.Answers
                .Include(a => a.Topic)
                .Include(a => a.User)
                .Where(a => a.TopicId == postId).OrderByDescending(u => u.DateOfCreate).ToList();
            return answers;
        }
    }
}