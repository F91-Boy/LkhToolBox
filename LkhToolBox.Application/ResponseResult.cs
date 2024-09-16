using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LkhToolBox.Application
{
    public class ResponseResult<T> where T : class
    {
        public bool IsSuccess { get; set; } = true;

        public string ErrorMessage { get; init; } = default!;

        public T Data { get; init; } = default!;
    }
}
