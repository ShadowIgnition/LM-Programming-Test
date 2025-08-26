using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace InfinityHeroes.News.Framework
{

	public interface INewsArticle
	{
		public string Title { get; }
		public DateTime Date { get; }
		public string Contents { get; }
		public IArticleSource Source { get; }

		public Task<string> GetImageURLAsync();

		public async Task<Texture2D> GetTextureAsync()
		{
			try
			{
				string url = await GetImageURLAsync();
				Texture2D texture = await ReadTextureFromWebAsync(url);

				if (texture != null)
				{
					return texture;
				}
			}
			catch (Exception e)
			{
				Debug.LogError(e);
			}

			return await ReadTextureFromWebAsync(BACKUP_IMAGE_URL);
		}

		static async Task<Texture2D> ReadTextureFromWebAsync(string URL)
		{
			if (string.IsNullOrWhiteSpace(URL))
			{
				Debug.LogError("Couldn't Read Texture From Web: Source URL was null or empty");
				return null;
			}

			try
			{
				using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(URL, true))
				{
					// Begin Request
					UnityWebRequestAsyncOperation asyncOp = webRequest.SendWebRequest();

					// Wait until request is done.
					while (asyncOp.isDone == false)
					{
						await Task.Yield();
					}

					// Read results
					if (webRequest.result == UnityWebRequest.Result.Success)
					{
						return DownloadHandlerTexture.GetContent(webRequest);
					}

					// Request failed, nothing to return.
					Debug.LogError($"{webRequest.error}, URL:{webRequest.url}");
					return null;
				}
			}
			catch (System.Exception e)
			{
				Debug.LogError(e);
				return null;
			}
		}

		public const string BACKUP_IMAGE_URL = "https://clan.akamai.steamstatic.com/images/5622060/d2cacaaf1eabcf5e84348737e3f0ff60f2470315.png";
	}
}
