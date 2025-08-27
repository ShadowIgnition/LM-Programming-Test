using Newtonsoft.Json;
using System.Text;

namespace InfinityHeroes.News.Steam
{
    public struct SteamAppNews
    {
		public SteamNewsArticle[] NewsItems { get; set; }

		[JsonConstructor]
        public SteamAppNews(SteamNewsArticle[] newsItems)
        {
            NewsItems = newsItems;
        }

        public override readonly string ToString()
        {
            StringBuilder sb = new();
            sb.Append(base.ToString());
            foreach (SteamNewsArticle item in NewsItems)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }
    }
}
