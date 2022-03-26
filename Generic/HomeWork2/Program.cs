namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set a variable to the Desktop path.
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            
            LocalFileLogger<int> loggerint = new LocalFileLogger<int>(docPath);

            loggerint.LogError("Test message for method LogError", new Exception("LogError"));
            loggerint.LogInfo("Test message for method LogInfo");
            loggerint.LogWarning("Test message for method LogWarning");
            
            LocalFileLogger<string> loggersting = new LocalFileLogger<string>(docPath);
            
            loggersting.LogError("Test message for method LogError", new Exception("LogError"));
            loggersting.LogInfo("Test message for method LogInfo");
            loggersting.LogWarning("Test message for method LogWarning");
            
        }
        
    }

    public interface ILogger
    {
        public void LogInfo(string message);
        public void LogError(string message, Exception exception);
        public void LogWarning(string message);
    }

    public class LocalFileLogger<T> : ILogger
    {
        private readonly string _pathFile;

        public LocalFileLogger(string pathFile)
        {
            _pathFile = pathFile;
        }

        public void LogInfo(string message)
        {
            string line = $"[Info]: [{typeof(T).Name}] : {message} \n";
            
            // Write the string to a new file named "LogFile.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(_pathFile, "LogFile.txt"), true))
            {
                outputFile.WriteLine(line);
            }
        }

        public void LogError(string message, Exception exception)
        {
            string line = $"[Error] : [{typeof(T).Name}] : {message}.{exception.Message} \n";
            
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(_pathFile, "LogFile.txt"), true))
            {
                outputFile.WriteLine(line);
            }
        }

        public void LogWarning(string message)
        {
            string line = $"[Warning]: [{typeof(T).Name}] : {message} \n";
            
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(_pathFile, "LogFile.txt"), true))
            {
                outputFile.WriteLine(line);
            }
        }
    }
}