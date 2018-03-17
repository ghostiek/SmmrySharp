using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SmmrySharp
{
    public class Error
    {
        [JsonProperty("sm_api_error")]
        public int Code { get; private set; }

        [JsonProperty("sm_api_message")]
        public string Message { get; private set; }
    }
}
