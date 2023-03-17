using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrosNexos.Domain.Common
{
    public class ResponseCommon<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
        public List<T> Results { get; set; } = new List<T>();
    }
}
