namespace HomeWork4
{
    class Program
    {

        static void Main(string[] args)
        {
            
            Console.WriteLine("Application launched");
            Console.WriteLine("Enter the request text to send. Type /exit to exit");
            var command = Console.ReadLine();
            List<string> argsList = new List<string>();

            while (command != "/exit")
            {
                argsList.Clear();
                Console.WriteLine("Enter the message arguments. If no arguments are needed, type /end");
                var arg = Console.ReadLine();
                while (arg != "/end")
                {
                    argsList.Add(arg);
                    Console.WriteLine(
                        "Enter the following query argument. To stop adding arguments write /end");
                    arg = Console.ReadLine();
                }

                new Thread(() => HandleWork(command, argsList.ToArray())).Start();
                
                Console.WriteLine("Enter the request text to send. Type /exit to exit");
                command = Console.ReadLine();
            }
            
            Console.WriteLine("The program has ended");
        }

        static void HandleWork(string command, string[] args)
        {
            DummyRequestHandler handler = new DummyRequestHandler();
            var messageId = Guid.NewGuid().ToString("D");
            Console.WriteLine($"Message '{command}' was sent. Assigned identifier {messageId}");
            try
            {
                var answerId = handler.HandleRequest(command, args);
                Console.WriteLine($"Message with identifier {messageId} received response {answerId}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Message with id {messageId} failed with error: {e.Message} ");
            }
        }
    }
}