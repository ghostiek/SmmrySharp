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
var smmryDownloader = new SmmryDownloader();
var json = smmryDownloader.GetJsonAsync(smmryParams);
```

Note: Every parameter is optional except your API key and website URL

# TODO

  1) Deserialize the JSON to make the data more user-friendly

Otherwise the Library is pretty straighforward and fully functional.
