using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Response
    {
        public bool status;
        public string reason;
        public string data;
        public Response(bool status1,string reason1, string data1)
        {
            status = status1;
            reason = reason1;
            data = data1;
        }
    }
}
