using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace tomticket_api
{
    public class MultipartFormItem
    {
        public HttpContent Content { get; set; }
        public string Name { get; set; }

        public MultipartFormItem(HttpContent content, string name)
        {
            Content = content;
            Name = name;
        }
    }
}
