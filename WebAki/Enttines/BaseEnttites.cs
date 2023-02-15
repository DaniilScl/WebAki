using System;

namespace WebAki.Enttines
{
    public class BaseEnttites
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}