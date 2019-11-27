using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfChat.models
{
    class Message
    {
        public Message(User user, string message)
        {
            User = user;
            MessageOut = message;
        }

        public User User { get; set; }
        public string MessageOut { get; set; }
    }
}
