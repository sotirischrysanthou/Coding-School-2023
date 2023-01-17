using Session_07;

internal class Program {
    private static void Main(string[] args) {
        ActionResolver resolver = new ActionResolver();
        ActionRequest request;
        ActionResponse response;
        String input = "";
        int i;
        while (input != "exit" && input != "Exit") {
            Console.WriteLine("Write 1(To Convert), 2(To Uppercase), 3(To Reverse) or Type exit(To Exit)");
            input = Console.ReadLine();
            ActionEnum actionEnum;
            if (Int32.TryParse(input, out i) && i > 0 && i <= 3) {
                Guid requestID = Guid.NewGuid();
                switch (i) {
                    case 1:
                        Console.WriteLine("Write an decimal number to convert it to binary.");
                        actionEnum = ActionEnum.Convert;
                        break;
                    case 2:
                        Console.WriteLine("Write a sentence with more than one word. ");
                        actionEnum = ActionEnum.UpperCase;
                        break;
                    case 3:
                        Console.WriteLine("Write a String not a number.");
                        actionEnum = ActionEnum.Reverse;
                        break;
                    default:
                        Console.WriteLine("Oopsiee something went wrong. if you don't know what went wrong contact support.");
                        return;
                }
                input = Console.ReadLine();
                request = new ActionRequest(requestID, input, actionEnum);
                response = resolver.Execute(request);
                Console.WriteLine("{0} : {1} : {2} ", response.RequestID, response.ResponseID, response.Output);
            }
        }
        resolver.Logger.ReadAll();

    }
}