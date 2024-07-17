using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace InfinityHeroes.News
{
    public static class TextureStreamer
    {

        public static IEnumerator ReadFromURL(string url, Action<Texture2D> callback)
        {
            using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
            {
                yield return uwr.SendWebRequest();

                if (uwr.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError(uwr.error);
                    yield return null;
                }

                // Get downloaded asset bundle
                callback.Invoke(DownloadHandlerTexture.GetContent(uwr));
            }
        }
    }
}
