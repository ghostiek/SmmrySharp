using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SmmrySharp
{
    public class SmmryError
    {
        [JsonProperty("sm_api_error")]
        public int Code { get; private set; }

        [JsonProperty("sm_api_message")]
        public string Message { get; private set; }
    }
}
