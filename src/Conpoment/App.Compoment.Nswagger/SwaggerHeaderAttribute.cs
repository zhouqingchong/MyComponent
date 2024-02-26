using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Compoment.Nswagger
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class SwaggerHeaderAttribute: Attribute
    {
        public string HeaderName { get; }
        public string? Description { get; }
        public string? DefaultValue { get; }
        public bool IsRequired { get; }

        public SwaggerHeaderAttribute(string headerName, string? description = null, string? defaultValue = null, bool isRequired = false)
        {
            HeaderName = headerName;
            Description = description;
            DefaultValue = defaultValue;
            IsRequired = isRequired;
        }
    }
}
