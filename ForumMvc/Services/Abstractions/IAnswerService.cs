using System.Linq;
using ForumMvc.Models;

namespace ForumMvc.Services.Abstractions
{
    public interface IAnswerService
    {
        public void AddAnswer(int userId, int postId, string answer);
        public IOrderedQueryable<Answer> GetAnswers(int postId);

    }
}