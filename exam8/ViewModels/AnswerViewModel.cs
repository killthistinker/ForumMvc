using System;

namespace exam8.ViewModels
{
    public class AnswerViewModel
    {
        public int UserId { get; set; }
        public int TopicId { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreate { get; set; }
    }
}