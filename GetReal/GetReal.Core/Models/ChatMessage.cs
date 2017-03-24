using System;

namespace GetReal.Core.Models
{
    public class ChatMessage : Model
    {
        public string Content { get; set; }

        public string UserName { get; set; }

		public DateTime DateCreated { get; set; }
    }
}
