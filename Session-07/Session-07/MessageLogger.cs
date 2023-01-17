using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_07 {
    internal class MessageLogger {
        // Properties
        public Message[] Messages { get; set; }
        public int pointer { get; set; }

        // Constructors
        public MessageLogger() {
            Messages = new Message[1000];
            pointer = 0;
        }

        public MessageLogger(int size) {
            Messages = new Message[size];
            pointer = 0;
        }

        // Methods
        public void ReadAll() {
            for (int i = 0; i < pointer; i++) {
                Console.WriteLine("{0} : {1} : {2}", Messages[i].ID, Messages[i].TimeStamp, Messages[i].Content);
            }
        }

        public void Clear() {
            for (int i = 0; i < pointer; i++) {
                Messages[i].ID = null;
                Messages[i].TimeStamp = null;
                Messages[i].Content = "";
            }
            pointer = 0;
        }

        public void Write(Message message) {
            Messages[pointer] = message;
            pointer++;
        }


    }
}
