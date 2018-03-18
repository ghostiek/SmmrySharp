# SmmrySharp
 
This is a library written in C# for http://smmry.com/

Available on NuGet https://www.nuget.org/packages/SmmrySharp/

## Dependencies
Dependency        | Version
----------------- | -------------
.NET Standard     | 2.0
Newtonsoft        | 11.0.1
System.Net.Http   | 4.3.3

## Example

This is how you would make your request
```cs
var smmryParam = new SmmryParameters()
    {
        ApiKey = "ApiKey",
        Url = "https://en.wikipedia.org/wiki/Augustus",
        SentenceCount = 3,
        KeywordCount = 24,
        IncludeBreaks = true,
        IncludeQuotes = true
    };
var smmry = new SmmryDownloader(smmryParam).Smmry;
```

Note: Every parameter is optional except your API key and website URL
