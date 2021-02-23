using System;
using System.ComponentModel.DataAnnotations;

namespace gotodo_api.Models
{
    public class TodoItem
    {
        public TodoItem(int id, string userId, string title, DateTime due, bool done)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Due = due;
            Done = done;
        }

        //[Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string  Title { get; set; }
        public DateTime Due { get; set; }
        public bool Done { get; set; }
    }
}