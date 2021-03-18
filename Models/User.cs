using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gotodo_api.Models
{
    public class User
    {
        public User(string userId, string username)
        {
            UserId = userId;
            Username = username;
        }

        public string UserId { get; set; }
        public string Username { get; set; }
    }
}