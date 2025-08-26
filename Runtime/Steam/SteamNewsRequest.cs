using System.Text;

namespace InfinityHeroes.News.Steam
{
    public readonly struct SteamNewsRequest
    {
        public int AppID { get; }
        public int? ArticleCount { get; }
        public int? MaxContentLength { get; }
        public SteamNewsFormat? Format { get; }

        public SteamNewsRequest(int appID, int? articleCount = null, int? maxContentLength = null, SteamNewsFormat? format = null)
        {
            AppID = appID;
            ArticleCount = articleCount;
            MaxContentLength = maxContentLength;
            Format = format;
        }

        public static implicit operator string(SteamNewsRequest request)
        {
            return request.ToString();
        }

        public override string ToString()
        {
            StringBuilder url = new();
            url.Append("https://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/?appid=" + AppID);
            if (ArticleCount.HasValue)
            {
                url.Append($"&count={ArticleCount}");
            }
            if (MaxContentLength.HasValue)
            {
                url.Append($"&maxlength={MaxContentLength}");
            }
            if (Format.HasValue)
            {
                url.Append($"&format={Format}");
            }
            return url.ToString();
        }

        public enum SteamNewsFormat { JSON, XML, VDF }
    }


}
