using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfChat.models
{
    class User
    {

        public string Name { get; set; }
        public List<Message> ListMessage { get; set; }
        public User(string name)
        {
            Name = name;
            ListMessage = new List<Message>();
        }


    }
}
