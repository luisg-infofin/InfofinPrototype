﻿using MongoDB.Entities;

namespace SearchService.Models
{
    public class Item : Entity
    {        
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string? CreationUser { get; set; }
        public string? UpdateUser { get; set; }
    }
}
