using System;
using Microsoft.AspNetCore.Identity;

namespace exam8.Models
{
    public class User : IdentityUser<int>
    { 
        public string Avatar { get; set; }
    }
}