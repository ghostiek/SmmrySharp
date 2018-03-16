using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Reflection;
using SmmrySharp.Attributes;

namespace SmmrySharp
{
    public class SmmryParameters : Dictionary<string, object>
    {
        [SmmryParameter("SM_API_KEY")]
        public string ApiKey
        {
            get => (string)this[GetSmmryParameterName()];
            set => this[GetSmmryParameterName()] = value;
        }

        [SmmryParameter("SM_URL")]
        public string Url
        {
            get => (string)this[GetSmmryParameterName()];
            set => this[GetSmmryParameterName()] = value;
        }

        [SmmryParameter("SM_LENGTH")]
        public int? SentenceCount
        {
            get => (int?)this[GetSmmryParameterName()];
            set => this[GetSmmryParameterName()] = value;
        }

        [SmmryParameter("SM_KEYWORD_COUNT")]
        public int? KeywordCount
        {
            get => (int?)this[GetSmmryParameterName()];
            set => this[GetSmmryParameterName()] = value;
        }

        [SmmryParameter("SM_QUOTE_AVOID")]
        public bool? IncludeQuotes
        {
            get => (bool?)this[GetSmmryParameterName()];
            set => this[GetSmmryParameterName()] = value;
        }

        [SmmryParameter("SM_WITH_BREAK")]
        public bool? IncludeBreaks
        {
            get => (bool?)this[GetSmmryParameterName()];
            set => this[GetSmmryParameterName()] = value;
        }

        private string GetSmmryParameterName([CallerMemberName] string propertyName = null)
        {
            return
                typeof(SmmryParameters).GetTypeInfo()
                    .DeclaredProperties.FirstOrDefault(x => x.Name == propertyName)
                    .GetCustomAttribute<SmmryParameterAttribute>()
                    .ToString();
        }

        public override string ToString()
        {
            //Skips SM_URL because that should be last and concats every parameter that is defined
            string url = $"?{string.Join("&", this.Where(x => x.Key != "SM_URL").Select(item => $"{item.Key}={item.Value}"))}";
            return string.Concat(url, $"&SM_URL={Url}");
        }
    }
}