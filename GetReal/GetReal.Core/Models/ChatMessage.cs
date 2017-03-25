using FirebaseSharp.Portable;
using System;
using static FirebaseSharp.Portable.ServerValue;

namespace GetReal.Core.Models
{
    public class ChatMessage
    {
        public string Content { get; set; }

        public string UserName { get; set; }
    }
}
