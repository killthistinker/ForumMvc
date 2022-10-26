using System;
using System.Collections.Generic;

namespace ForumMvc.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreate { get; set; }
        public List<Answer> Answers { get; set; }

        public Topic()
        {
            Answers = new List<Answer>();
        }
    }
}