using Api.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Common.Helpers
{
    public class ResponseHelper
    {
        public static ResponseMessage<T> GetResponseMessage<T>(int statusCode, string message, T data)
        {
            Status status = new Status()
            {
                Code = statusCode
            };
            if (!string.IsNullOrEmpty(message))
            {
                status.Value = message;
            }
            ResponseMessage<T> responseMessage = new ResponseMessage<T>()
            {
                status = status,
                data = data
            };
            return responseMessage;
        }
        public static ResponseMessage<object> GetResponseMessage(int statusCode, string message)
        {
            return GetResponseMessage<object>(statusCode, message, null);
        }
        public static ResponseMessage<T> GetSuccessResponseMessage<T>(T data)
        {
            return GetResponseMessage<T>(200, "Successful", data);
        }
        public static ResponseMessage<object> GetSuccessResponseMessage()
        {
            return GetResponseMessage<object>(200, "Successful", null);
        }
    }
}
