using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BE.Model.Respuesta
{
    public class ResponseModel<T> 
    {
        public ResponseModel() { }
        public ResponseModel(bool succefull, string message,T data ,List<string> errors)
        { 
            Success = succefull;
            Message = message;
            Data = data;
            Errors = errors;
        }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; } 
        public List<string>? Errors { get; set; } =  null;
    }
}
