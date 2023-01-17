using Session_07;

internal class Program {
    private static void Main(string[] args) {
        MessageLogger msglog = new MessageLogger();
        Message msg;
        String content = Console.ReadLine();
        while (content != "exit") {
            msg = new Message(Guid.NewGuid(), DateTime.Now, content);
            msglog.Write(msg);
            content = Console.ReadLine();   
        }

        Console.WriteLine("ReadAll\n-----");
        msglog.ReadAll();
        Console.WriteLine("-----\nClear\n-----");
        msglog.Clear();
        Console.WriteLine("ReadAll\n-------");
        msglog.ReadAll();
    }
}