
using System.Text.Json.Serialization;

public partial class Shadiao
{
    [JsonPropertyName("data")]
    public Data Data { get; set; }
}

public partial class Data
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }
}

public partial class WangYiYunDuanZi
{
    [JsonPropertyName("success")]
    public string Success { get; set; }

    [JsonPropertyName("duanzi")]
    public string Duanzi { get; set; }

    [JsonPropertyName("qiafan")]
    public bool Qiafan { get; set; }
}

    public partial class SweetNothings
    {
        [JsonPropertyName("code")]
        public long Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("returnObj")]
        public ReturnObj ReturnObj { get; set; }
    }

    public partial class ReturnObj
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("likeCount")]
        public long LikeCount { get; set; }

        [JsonPropertyName("dislikeCount")]
        public long DislikeCount { get; set; }
    }

