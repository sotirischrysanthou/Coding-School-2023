using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_07 {
    internal class Message {
        // Properties
        public Guid? ID { get; set; }
        public DateTime? TimeStamp { get; set; }
        public String Content { get; set; }

        // Constractors
        public Message(Guid id, DateTime timeStamp, String content) { 
            ID = id;
            TimeStamp = timeStamp;
            Content = content;
        }

    }
}
