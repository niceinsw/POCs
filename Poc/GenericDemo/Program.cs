using System;
using System.Collections.Generic;

namespace GenericDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.ReadKey();
        }
    }


    public class MyHandler
    {
        public TOutput GetResult<TInput, TOutput>(TInput input) where TInput : class, new()
        {

        }
    }

    public class MyService
    {

    }

    public class ResponseDto<T>
    {
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
        public T Response { get; set; }
        public int ErrorCode { get; set; }
    }

    public static class MyExtensionMethods
    {
        public static ResponseDto<T> ToResponse<T>(this T response)
        {
            return new ResponseDto<T>()
            {
                Errors = null,
                IsSuccess = true,
                Response = response,
                ErrorCode = 0
            };
        }
    }
}
