using System.Linq;
using System.Threading.Tasks;
using ForumMvc.Models;
using ForumMvc.Services.Abstractions;
using ForumMvc.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumMvc.Controllers
{
    public class AnswerController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IAnswerService _answerService;

        public AnswerController(UserManager<User> userManager, IAnswerService answerService)
        {
            _userManager = userManager;
            _answerService = answerService;
        }


        [HttpGet]
        public async Task<IActionResult> AddAnswer(int postId, string answer,int page =1)
        {
            int.TryParse(_userManager.GetUserId(User), out int userId);
            _answerService.AddAnswer(userId, postId, answer);
            IQueryable<Answer> answers = _answerService.GetAnswers(postId);
            if (answers is null)
            {
                return RedirectToAction("Error", "Errors", new {statusCode = 404});
            }
            int pageSize = 3;
            var count = await answers.CountAsync();
            var items = await answers.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
 
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Answers = items
            };
            return PartialView("PatrialViews/AnswerPatrialView", viewModel);
        }
    }
}