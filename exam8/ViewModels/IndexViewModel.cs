using System.Collections.Generic;
using exam8.Models;

namespace exam8.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Answer> Answers { get; set; }
        public PageViewModel PageViewModel { get; set; }

        public Topic Topic { get; set; }
    }
}