using System.Collections.Generic;
using ForumMvc.Models;

namespace ForumMvc.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Answer> Answers { get; set; }
        public PageViewModel PageViewModel { get; set; }

        public Topic Topic { get; set; }
    }
}