using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SmmrySharp
{
    public class Smmry
    {
        [JsonProperty("sm_api_character_count")]
        public string CharacterCount { get; private set; }

        [JsonProperty("sm_api_content_reduced")]
        public string ContentReduced { get; private set; }

        [JsonProperty("sm_api_title")]
        public string Title { get; private set; }

        [JsonProperty("sm_api_content")]
        public string Content { get; private set; }

        [JsonProperty("sm_api_limitation")]
        public string Limitation { get; private set; }
    }
}
