namespace HomeWork1
{
    class Program
    {
        //Subscriber
        static void Main(string[] args)
        {
            Publisher p = new Publisher();
            p.OnKeyPressed += p_CharacterEnter;
            p.Run();
            
        }

        static void p_CharacterEnter(object sender, char c)
        {
            Console.WriteLine("The character {0} was entered.", c);
        }
    }
    
    //Publisher

    class Publisher
    {
        public void Run()
        {
            
            Console.WriteLine("enter a character, to exit enter a character c");
            while (true)
            {   
                Console.WriteLine("enter one");
                var c = Console.ReadKey(true).KeyChar;
                if (c != 'c')
                {
                    CharacterEntered(c);
                }
                else
                {
                    Console.WriteLine("Character c was entered");
                    Console.WriteLine("Exit");
                    Environment.Exit(0);
                }
                
            }
        }

        protected virtual void CharacterEntered(char c)
        {
            EventHandler<char>? handler = OnKeyPressed;

            if (handler != null)
            {
                handler(this, c);
            }
            
        }
        public event EventHandler<char>? OnKeyPressed;
    }
}
