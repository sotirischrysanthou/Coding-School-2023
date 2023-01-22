using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLoggerLib {
    public class MessageLogger {
        // Properties
        public List<Message> Messages { get; set; }

        // Constructors
        public MessageLogger() {
            Messages = new List<Message>();
        }

        // Methods
        public void ReadAll() {
            using (StreamWriter writetext = new StreamWriter("LogCalculator.txt")) {
                foreach (var message in Messages) {
                    writetext.WriteLine("{0} : {1} : {2}", message.ID, message.TimeStamp, message.Content);
                }
            }
        }

        public void Clear() {
            Messages.Clear();
        }

        public void Write(Message message) {
            Messages.Add(message);
        }


    }
}
