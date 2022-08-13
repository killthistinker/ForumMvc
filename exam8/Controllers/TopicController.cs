using System.Linq;
using System.Threading.Tasks;
using exam8.Models;
using exam8.Services.Abstractions;
using exam8.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace exam8.Controllers
{
    [Authorize]
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;
        private readonly UserManager<User> _userManager;
        private readonly IAnswerService _answerService;

        public TopicController(ITopicService topicService, UserManager<User> userManager, IAnswerService answerService)
        {
            _topicService = topicService;
            _userManager = userManager;
            _answerService = answerService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            TopicViewModel model = new TopicViewModel();
            int.TryParse(_userManager.GetUserId(User), out int userId);
            model.AuthorizedUserId = userId;
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(TopicViewModel model)
        {
            if (ModelState.IsValid)
            {
                _topicService.CreateTopic(model);
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Error", "Errors", new {statusCode = 404});
        }

        [HttpGet]
        public async Task<IActionResult> GetInfo(int id, int page = 1)
        {
            Topic topic = _topicService.GetTopic(id);
            if (topic is null)
                return RedirectToAction("Error", "Errors", new {statusCode = 404});
            IQueryable<Answer> answers = _answerService.GetAnswers(topic.Id);
            int pageSize = 3;
            var count = await answers.CountAsync();
            var items = await answers.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Answers = items,
                Topic = topic
            };
            
            return View(viewModel);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPage(int id, int page = 1)
        {
            Topic topic = _topicService.GetTopic(id);
            if (topic is null)
                return RedirectToAction("Error", "Errors", new {statusCode = 404});
            IQueryable<Answer> answers = _answerService.GetAnswers(topic.Id);
            int pageSize = 3;
            var count = await answers.CountAsync();
            var items = await answers.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Answers = items,
                Topic = topic
            };
            
            return PartialView("PatrialViews/TopicInfoPartialView",viewModel);
        }
    }
}
