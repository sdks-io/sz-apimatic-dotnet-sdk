
# Answer Http Response

Buffered JSON response body for `POST /v1/answer`.

*This model accepts additional fields of type object.*

## Structure

`AnswerHttpResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Answer` | `string` | Required | Markdown answer text. Inline citations follow the form<br>`text ([Source Name](url))`. |
| `Citations` | [`List<HttpCitation>`](../../doc/models/http-citation.md) | Required | The sources the answer was grounded in. Every source the answer was<br>given is returned, whether or not the text cites it. |
| `AdditionalProperties` | `object this[string key]` | Optional | - |

## Example

```csharp
using SeltzApi.Standard.Models;
using SeltzApi.Standard.Utilities;
using System.Collections.Generic;

AnswerHttpResponse answerHttpResponse = new AnswerHttpResponse
{
    Answer = "answer4",
    Citations = new List<HttpCitation>
    {
        new HttpCitation
        {
            Url = "url2",
            Content = "content2",
            ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
        },
    },
    ["exampleAdditionalProperty"] = ApiHelper.JsonDeserialize<object>("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};
```

