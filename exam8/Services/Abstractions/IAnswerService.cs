using System.Collections.Generic;
using exam8.Models;

namespace exam8.Services.Abstractions
{
    public interface IAnswerService
    {
        public void AddAnswer(int userId, int postId, string answer);
        public List<Answer> GetAnswers(int postId);

    }
}