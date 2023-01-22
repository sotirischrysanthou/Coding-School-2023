using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLoggerLib {
    public class Message {
        // Properties
        public Guid? ID { get; set; }
        public DateTime? TimeStamp { get; set; }
        public String Content { get; set; }

        // Constractors
        public Message(String content) { 
            ID = Guid.NewGuid();
            TimeStamp = DateTime.Now;
            Content = content;
        }

    }
}
