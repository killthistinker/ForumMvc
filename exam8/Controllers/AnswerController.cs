using System.Collections.Generic;
using exam8.Models;
using exam8.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace exam8.Controllers
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
        public IActionResult AddAnswer(int postId, string answer)
        {
            int.TryParse(_userManager.GetUserId(User), out int userId);
            _answerService.AddAnswer(userId, postId, answer);
            var answers = _answerService.GetAnswers(postId);
            if (answers is null)
            {
                return RedirectToAction("Error", "Errors", new {statusCode = 404});
            }
            return PartialView("PatrialViews/AnswerPatrialView", answers);
        }
    }
}