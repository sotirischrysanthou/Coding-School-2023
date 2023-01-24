using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLoggerLib {
    public class ActionResolver {
        // Properties
        public MessageLogger Logger { get; set; }

        // Constructors
        public ActionResolver() {
            Logger = new MessageLogger();
        }


        // Methods
        public ActionResponse Execute(ActionRequest actionRequest) {
            ActionResponse response = new ActionResponse(actionRequest.ID);
            String? output;
            Log("EXECUTION START");
            try {
                if (actionRequest.ActionObj.Run(actionRequest.Input, out output)) {
                    response.SetOutput(output);
                } else {
                    output = String.Format("ERROR : {0}", output);
                    response.SetOutput(output);
                }
                Log(String.Format("Try to do {0} \"{1}\" and result is : {2}", actionRequest.ActionObj.Message(), actionRequest.Input, response.Output));
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

        //private MessageLoggerLib.Action NewAction(Type ActionType) {
        //    MessageLoggerLib.Action action;
        //    switch (actionEnum) {
        //        case ActionEnum.Convert:
        //            action = new ActionConvert();
        //            break;
        //        case ActionEnum.UpperCase:
        //            action = new ActionUppercase();
        //            break;
        //        case ActionEnum.Reverse:
        //            action = new ActionReverse();
        //            break;
        //        default:
        //            action = new MessageLoggerLib.Action();
        //            break;
        //    }
        //    return action;
        //}
    }
}
