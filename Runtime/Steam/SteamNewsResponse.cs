using InfinityHeroes.News.Framework;
using Newtonsoft.Json;
using System;

namespace InfinityHeroes.News.Steam
{
    public record SteamNewsResponse : INewsResponse
    {
        public SteamAppNews AppNews { get; }
        public INewsArticle[] Articles { get; }
        public string ErrorMessage { get; }
        public bool IsError { get { return ErrorMessage != null; } }

        [JsonConstructor]
        public SteamNewsResponse(SteamAppNews appNews)
        {
            Articles = new INewsArticle[appNews.NewsItems.Length];
            AppNews = appNews;
            Array.Copy(appNews.NewsItems, Articles, appNews.NewsItems.Length);
            ErrorMessage = null;
        }

        public SteamNewsResponse(string errorMessage)
        {
            Articles = Array.Empty<INewsArticle>();
            AppNews = new();
            ErrorMessage = errorMessage;
        }
    }
}