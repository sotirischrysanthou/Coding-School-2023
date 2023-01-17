using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_07 {
    internal class ActionResolver {
        // Properties
        public MessageLogger Logger { get; set; }

        // Constructors
        public ActionResolver() {
            Logger = new MessageLogger();
        }

        public ActionResolver(int sizeOfLogger) {
            Logger = new MessageLogger(sizeOfLogger);
        }

        // Methods
        public ActionResponse Execute(ActionRequest actionRequest) {
            Message message;
            ActionResponse response;
            Guid responseID = Guid.NewGuid();
            Guid messageID = Guid.NewGuid();
            Session_07.Action action;
            String? output;
            switch (actionRequest.Action) {
                case ActionEnum.Convert:
                    action = new ActionConvert();
                    break;
                case ActionEnum.UpperCase:
                    action = new ActionUppercase();
                    break;
                case ActionEnum.Reverse:
                    action = new ActionReverse();
                    break;
                default:
                    action = new Session_07.Action();
                    break;
            }
            if (action.Run(actionRequest.Input, out output)) {
                response = new ActionResponse(actionRequest.ID, responseID, output);
            } else {
                output = String.Format("ERROR : {0}", output);
                response = new ActionResponse(actionRequest.ID, responseID, output);
            }
            message = new Message(messageID, DateTime.Now, output);
            Logger.Write(message);
            return response;
        }
    }
}
