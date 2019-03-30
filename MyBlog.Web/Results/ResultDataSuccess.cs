using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Web.Results
{
    public class ResultDataSuccess : MyblogBaseResult
    {
        public string GuidRequest { get; set; }

        public int Code { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
