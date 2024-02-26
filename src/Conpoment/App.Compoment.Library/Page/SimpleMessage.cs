using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Compoment.Library.Page
{
    public class SimpleMessage<T>
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
        public T data { get; set; } = default(T);
    }
}
