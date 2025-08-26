﻿using InfinityHeroes.News.Framework;
using Newtonsoft.Json;
using System;

namespace InfinityHeroes.News.Steam
{
    public record SteamNewsResponse : INewsResponse
    {
        public AppNews AppNews { get; }
        public INewsArticle[] NewsItems { get; }
        public string ErrorMessage { get; }
        public bool IsError { get { return ErrorMessage != null; } }

        [JsonConstructor]
        public SteamNewsResponse(AppNews appNews)
        {
            NewsItems = new INewsArticle[appNews.NewsItems.Length];
            AppNews = appNews;
            Array.Copy(appNews.NewsItems, NewsItems, appNews.NewsItems.Length);
            ErrorMessage = null;
        }

        public SteamNewsResponse(string errorMessage)
        {
            NewsItems = Array.Empty<INewsArticle>();
            AppNews = new();
            ErrorMessage = errorMessage;
        }
    }
}