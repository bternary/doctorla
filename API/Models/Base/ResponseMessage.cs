using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Models.Base
{
    public class ResponseMessage<T>
    {
        public Status status { get; set; }
        public T data { get; set; }
    }
}
