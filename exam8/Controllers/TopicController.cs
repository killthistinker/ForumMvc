using exam8.Models;
using exam8.Services.Abstractions;
using exam8.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace exam8.Controllers
{
    [Authorize]
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;
        private readonly UserManager<User> _userManager;

        public TopicController(ITopicService topicService, UserManager<User> userManager)
        {
            _topicService = topicService;
            _userManager = userManager;
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
        public IActionResult GetInfo(int id)
        {
            Topic topic = _topicService.GetTopic(id);
            if (topic is null)
                return RedirectToAction("Error", "Errors", new {statusCode = 404});
            
            return View(topic);
        }
    }
}