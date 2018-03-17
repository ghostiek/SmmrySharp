using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Reflection;
using SmmrySharp.Attributes;

namespace SmmrySharp
{
    public class SmmryParameters : Dictionary<string, object>
    {
        /// <summary>
        /// Your API Key
        /// </summary>
        [SmmryParameter("SM_API_KEY", true)]
        public string ApiKey
        {
            get => (string)(TryGetValue(GetSmmryParameterName(), out var result) ? result : null);
            set => this[GetSmmryParameterName()] = value;
        }

        /// <summary>
        /// The webpage to summarize
        /// </summary>
        [SmmryParameter("SM_URL", true)]
        public string Url
        {
            get => (string)(TryGetValue(GetSmmryParameterName(), out var result) ? result : null);
            set => this[GetSmmryParameterName()] = value;
        }

        /// <summary>
        /// The number of sentences returned, default 7.
        /// </summary>
        [SmmryParameter("SM_LENGTH", true)]
        public int? SentenceCount
        {
            get => (int?)(TryGetValue(GetSmmryParameterName(), out var result) ? result : null);
            set => this[GetSmmryParameterName()] = value;
        }

        /// <summary>
        /// The number of keywords to return
        /// </summary>
        [SmmryParameter("SM_KEYWORD_COUNT", true)]
        public int? KeywordCount
        {
            get => (int?)(TryGetValue(GetSmmryParameterName(), out var result) ? result : null);
            set => this[GetSmmryParameterName()] = value;
        }

        /// <summary>
        /// Decides if the string [BREAK] will be inserted between sentences
        /// </summary>
        [SmmryParameter("SM_WITH_BREAK", false)]
        public bool? IncludeBreaks
        {
            get => (bool?)(TryGetValue(GetSmmryParameterName(), out var result) ? result : null);
            set => this[GetSmmryParameterName()] = value;
        }

        /// <summary>
        /// Decides if the HTML entities will be converted to their applicable chars
        /// </summary>
        [SmmryParameter("SM_WITH_ENCODE", false)]
        public bool? Encode
        {
            get => (bool?)(TryGetValue(GetSmmryParameterName(), out var result) ? result : null);
            set => this[GetSmmryParameterName()] = value;
        }

        /// <summary>
        /// Returns summary regardless of quality or length
        /// </summary>
        [SmmryParameter("SM_IGNORE_LENGTH", false)]
        public bool? IgnoreLength
        {
            get => (bool?)(TryGetValue(GetSmmryParameterName(), out var result) ? result : null);
            set => this[GetSmmryParameterName()] = value;
        }

        /// <summary>
        /// Decides if Sentences with quotations will be included.
        /// </summary>
        [SmmryParameter("SM_QUOTE_AVOID", false)]
        public bool? IncludeQuotes
        {
            get => (bool?)(TryGetValue(GetSmmryParameterName(), out var result) ? result : null);
            //Only reason I'm reversing the value is because of inconsistent naming from the API
            set => this[GetSmmryParameterName()] = !value;
        }

        /// <summary>
        /// Decides if the summary should include questions or not
        /// </summary>
        [SmmryParameter("SM_QUESTION_AVOID", false)]
        public bool? IncludeQuestion
        {
            get => (bool?)(TryGetValue(GetSmmryParameterName(), out var result) ? result : null);
            set => this[GetSmmryParameterName()] = !value;
        }

        /// <summary>
        /// Decides if the summary should include sentences with exclamation marks  or not
        /// </summary>
        [SmmryParameter("SM_EXCLAMATION_AVOID", false)]
        public bool? IncludeExclamation
        {
            get => (bool?)(TryGetValue(GetSmmryParameterName(), out var result) ? result : null);
            //Only reason I'm reversing the value is because of inconsistent naming from the API
            set => this[GetSmmryParameterName()] = !value;
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
            //Gets all the parameters that require a parameter
            var haveParameters = GetType().GetTypeInfo()
                .DeclaredProperties
                .Where(x => (x.GetCustomAttribute<SmmryParameterAttribute>().HasParameter))
                .Select(x => x.GetCustomAttribute<SmmryParameterAttribute>().Name);

            //Gets all the parameters that don't require a parameter
            var doNotHaveParameters = GetType().GetTypeInfo()
                .DeclaredProperties
                .Where(x => !(x.GetCustomAttribute<SmmryParameterAttribute>().HasParameter))
                .Select(x => x.GetCustomAttribute<SmmryParameterAttribute>().Name);

            //Skips SM_URL and the ones without a parameter because SM_URL should be last
            var urlWithParams = this.Where(x =>
                 x.Key != "SM_URL" &&
                 haveParameters
                    .Any(param => x.Key == param))
                .Select(item => $"{item.Key}={item.Value}");

            var urlWithoutParams = this.Where(x =>
                x.Key != "SM_URL" &&
                doNotHaveParameters
                    .Any(param => param == x.Key) &&
                (bool)x.Value)
                .Select(item => item.Key);

            var url = $"?{string.Join("&", urlWithParams.Concat(urlWithoutParams))}";
            return string.Concat(url, $"&SM_URL={Url}");
        }
    }
}