using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMessageApp.Model.Dto
{
    public class ServiceResponse
    {
        public string Response { get; set; }
        public bool WasSuccess { get; set; }
    }

    public class ChatResponse : ServiceResponse
    {
        public string Message { get; set; }
    }
}
