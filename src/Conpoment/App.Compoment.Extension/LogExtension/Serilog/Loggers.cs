using Serilog;

namespace App.Compoment.Extension.LogExtension.Serilog
{
    public class Loggers : ILoggers
    {
        public void Error(string messageTemplate)
        {
            Log.Error(messageTemplate);
        }

        public void Error<T>(string messageTemplate, T propertyValue)
        {
            Log.Error<T>(messageTemplate, propertyValue);
        }

        public void Error(string messageTemplate, params object?[]? propertyValues)
        {
            Log.Error(messageTemplate, propertyValues);
        }

        public void Information(string messageTemplate)
        {
            Log.Information(messageTemplate);
        }

        public void Information<T>(string messageTemplate, T propertyValue)
        {
            Log.Information<T>(messageTemplate, propertyValue);
        }

        public void Information(string messageTemplate, params object?[]? propertyValues)
        {
            Log.Information(messageTemplate, propertyValues);
        }

        public void Warning(string messageTemplate)
        {
           Log.Warning(messageTemplate);
        }

        public void Warning<T>(string messageTemplate, T propertyValue)
        {
            Log.Warning<T>(messageTemplate, propertyValue);
        }

        public void Warning(string messageTemplate, params object?[]? propertyValues)
        {
           Log.Warning(messageTemplate, propertyValues);
        }
    }
}
