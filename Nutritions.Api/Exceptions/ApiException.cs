using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Nutritions.Api
{
    public class ApiException : Exception
    {
        public ApiException(HttpStatusCode status = HttpStatusCode.InternalServerError, string code = "", string details= "") : base(details)
        {
            this.Code = code;
            this.StatusCode = status;
            this.Details = details;
        }
        
        public HttpStatusCode StatusCode { get; set; }
        public string Code { get; set; }
        public string Details { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(new { code = Code, details = Details});
        }

    }
}
