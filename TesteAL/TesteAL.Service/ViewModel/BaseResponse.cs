using System;
using System.Collections.Generic;
using System.Text;

namespace TesteAL.Service.ViewModel
{
    public class BaseResponse<T> where T : class
    {
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
