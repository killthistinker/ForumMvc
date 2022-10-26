using System.Linq;
using ForumMvc.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ForumMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITopicService _topicService;
        public HomeController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        public IActionResult Index()
        {
            var topic = _topicService.GetTopics();
            return View(topic.ToList());
        }
        
    }
}