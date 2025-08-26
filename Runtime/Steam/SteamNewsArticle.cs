using InfinityHeroes.News.Framework;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InfinityHeroes.News.Steam
{
	public record SteamNewsArticle : INewsArticle
	{
		public string Author { get; }
		public string Title { get; }
		public DateTime Date { get; }
		public string Contents { get; }
		public IArticleSource Source { get; }

		[JsonConstructor]
		public SteamNewsArticle(string title, long date, string contents, string url, string author)
		{
			Author = author;
			Title = title;
			Date = DateTimeOffset.FromUnixTimeSeconds(date).DateTime;
			Source = new SteamArticleSource(url);
			Contents = GetFirstSentences(contents);
		}

		public async Task<string> GetImageURLAsync()
		{
			string imageURL = INewsArticle.BACKUP_IMAGE_URL;

			if (Source is SteamArticleSource steamArticleSource)
			{
				using (HttpClient httpClient = new())
				{
					string html = await httpClient.GetStringAsync(steamArticleSource.URL);

					Match match = Regex.Match(html, METADATA, RegexOptions.IgnoreCase);

					if (match.Success)
					{
						imageURL = match.Groups[1].Value;
					}
				}
			}
			return imageURL;
		}

		static string GetFirstSentences(string input, int sentenceCount = 2)
		{
			string cleaned = StripSteamMarkup(input);

			// Match sentences ending in ., !, or ? followed by space or end of string
			MatchCollection matches = Regex.Matches(cleaned, @"[^.!?]+[.!?]+(\s|$)");

			string result = "";
			for (int i = 0; i < Math.Min(sentenceCount, matches.Count); i++)
			{
				result += matches[i].Value;
			}

			return result.Trim();
		}

		static string StripSteamMarkup(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return input;
			}

			input = Regex.Replace(input, @"\n{2,}", "\n");
			input = Regex.Replace(input, @"\[(p)\]", "[p]\n");
			// Remove all [bracketed content], non-greedy match
			input = Regex.Replace(input, @"\[(.*?)\]", string.Empty);
			input = Regex.Replace(input, @"\s{2,}", " ");
			return input.Trim();
		}



		const string METADATA = "<meta[^>]*property=[\"']og:image[\"'][^>]*content=[\"']([^\"']+)[\"']";
	}
}