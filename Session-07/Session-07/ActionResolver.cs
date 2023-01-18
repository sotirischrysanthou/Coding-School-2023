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
            ActionResponse response = new ActionResponse(actionRequest.ID);
            String? output;
            Log("EXECUTION START");
            try {
                Session_07.Action action = NewAction(actionRequest.Action);
                if (action.Run(actionRequest.Input, out output)) {
                    response.SetOutput(output);
                } else {
                    output = String.Format("ERROR : {0}", output);
                    response.SetOutput(output);
                }
                Log(String.Format("Try to do {0} \"{1}\" and result is : {2}", actionRequest.Action, actionRequest.Input, response.Output));
            } catch (Exception ex) {
                Log(ex.Message);
            } finally {
                Log("EXECUTION END");
            }
            return response;
        }

        private void Log(string text) {
            Message message = new Message("---------------");
            Logger.Write(message);
            message = new Message(text);
            Logger.Write(message);
        }

        private Session_07.Action NewAction(ActionEnum actionEnum) {
            Session_07.Action action;
            switch (actionEnum) {
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
            return action;
        }
    }
}
