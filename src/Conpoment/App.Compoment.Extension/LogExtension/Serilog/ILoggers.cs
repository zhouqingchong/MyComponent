using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Compoment.Extension.LogExtension.Serilog
{
    public interface ILoggers
    {
        void Information(string messageTemplate);
        void Information<T>(string messageTemplate, T propertyValue);
        void Information(string messageTemplate, params object?[]? propertyValues);

        void Warning(string messageTemplate);
        void Warning<T>(string messageTemplate, T propertyValue);
        void Warning(string messageTemplate, params object?[]? propertyValues);

        void Error(string messageTemplate);
        void Error<T>(string messageTemplate, T propertyValue);
        void Error(string messageTemplate, params object?[]? propertyValues);

    }
}
