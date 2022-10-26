using ForumMvc.Models;
using ForumMvc.ViewModels;

namespace ForumMvc.Helpers
{
    public static class UserRegistrationMapper
    {
        public static User MapToUser(this RegisterViewModel self)
        {
            User user = new User
            {
                Email = self.Email,
                UserName = self.UserName,
                Avatar = self.ImagePath,
            };
            return user;
        }
    }
}