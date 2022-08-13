using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace exam8.ViewModels
{
    public class TopicViewModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Description { get; set; }
        public int AuthorizedUserId { get; set; }
    }
}