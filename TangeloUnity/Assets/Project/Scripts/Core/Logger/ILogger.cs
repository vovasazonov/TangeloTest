namespace Project.Scripts.Core.Logger
{
    public interface ILogger
    {
        void Log(string message);
        void LogError(string message);
    }
}