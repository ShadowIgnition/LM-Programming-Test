using InfinityHeroes.News.Steam;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace InfinityHeroes.News.Framework
{
	public class NewsClient
	{
		public async Task<INewsResponse> GetArticlesAsync()
		{
			SteamNewsRequest steamNewsRequest = new(STEAM_APP_ID, ARTICLES_COUNT);
			m_CurrentRequest?.Abort();

			try
			{
				using (m_CurrentRequest = UnityWebRequest.Get(steamNewsRequest))
				{
					m_CurrentRequest.SendWebRequest();

					while (!m_CurrentRequest.isDone)
					{
						await Task.Yield();
					}

					if (m_CurrentRequest.result != UnityWebRequest.Result.Success)
					{
						return new SteamNewsResponse(m_CurrentRequest.error);
					}

					string responseBody = m_CurrentRequest.downloadHandler.text;
					return JsonConvert.DeserializeObject<SteamNewsResponse>(responseBody);
				}
			}
			catch (Exception ex)
			{
				return new SteamNewsResponse(ex.Message);
			}
		}

		UnityWebRequest m_CurrentRequest;
		const int ARTICLES_COUNT = 3;
		const int STEAM_APP_ID = 257730;
	}
}