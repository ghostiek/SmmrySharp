# SmmrySharp
 
This is a library written in C# for http://smmry.com/


# Example

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
var smmry = new SmmryDownloader().Smmry;
```

Note: Every parameter is optional except your API key and website URL
