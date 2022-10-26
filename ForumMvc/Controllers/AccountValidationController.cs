using System.Linq;
using ForumMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumMvc.Controllers
{
    public class AccountValidationController : Controller
    {
        private readonly ForumContext _context;

        public AccountValidationController(ForumContext context)
        {
            _context = context;
        }

        public bool CheckAccountEmail(string email)
        {
            bool validation = !_context.Users.AsEnumerable().Any(p => p.Email.Equals(email));
            return validation;
        }

        public bool CheckAccountName(string userName)
        {
            bool validation = !_context.Users.AsEnumerable().Any(p => p.UserName.Equals(userName));
            return validation;
        }
    }
}