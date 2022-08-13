using System.Linq;
using exam8.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;


namespace exam8.Controllers
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