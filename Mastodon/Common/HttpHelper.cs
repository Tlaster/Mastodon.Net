using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Mastodon.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mastodon.Common
{
    internal static class HttpHelper
    {
        public const string HTTPS = "https://";
        public const string HTTP = "http://";
        private static string UrlEncode(string url, IEnumerable<KeyValuePair<string, string>> param)
            => param != null ? 
            $"{url}?{string.Join("&", param.Where(kvp => !string.IsNullOrEmpty(kvp.Value) && (!int.TryParse(kvp.Value, out int intValue) || intValue > 0) && (!bool.TryParse(kvp.Value, out bool boolValue) || boolValue)).Select(kvp => $"{kvp.Key}={kvp.Value}"))}" : 
            url;

        public static IEnumerable<KeyValuePair<string, string>> ArrayEncode<T>(string paramName, params T[] values)
        {
            paramName = $"{paramName}[]";
            return values.Select(value => new KeyValuePair<string, string>(paramName, value.ToString()));
        }

        private static HttpClient GetHttpClient(string token, string tokenType = "Bearer") => string.IsNullOrEmpty(token)
            ? new HttpClient()
            : new HttpClient
            {
                DefaultRequestHeaders = {Authorization = new AuthenticationHeaderValue(tokenType, token)}
            };

        public static async Task<string> GetAsync(string url, string token, IEnumerable<KeyValuePair<string, string>> param)
        {
            using (var client = GetHttpClient(token))
                return CheckForError(await client.GetStringAsync(UrlEncode(url, param)));
        }
        public static async Task<T> GetAsync<T>(string url, string token, IEnumerable<KeyValuePair<string, string>> param) => JsonConvert.DeserializeObject<T>(await GetAsync(url, token, param));

        public static async Task<ArrayModel<T>> GetArrayAsync<T>(string url, string token, IEnumerable<KeyValuePair<string, string>> param)
        {
            using (var client = GetHttpClient(token))
            using (var res = await client.GetAsync(UrlEncode(url, param)))
            {
                res.Headers.TryGetValues("Link", out IEnumerable<string> values);
                var links = values.FirstOrDefault().Split(',').Select(s => Regex.Match(s, "<.*\\?(max_id|since_id)=([0-9]*)>; rel=\"(.*)\"").Groups).ToList();
                int.TryParse(links.FirstOrDefault(m => m[1].Value == "max_id")[2].Value, out int maxId);
                int.TryParse(links.FirstOrDefault(m => m[1].Value == "since_id")[2].Value, out int sinceId);
                return new ArrayModel<T>
                {
                    MaxId = maxId,
                    SinceId = sinceId,
                    Result = JsonConvert.DeserializeObject<T[]>(await res.Content.ReadAsStringAsync())
                };
            }
        }

        public static async Task<TModel> PostAsync<TModel, TValue>(string url, string token, IEnumerable<KeyValuePair<string, TValue>> param)
            where TValue : HttpContent => JsonConvert.DeserializeObject<TModel>(await PostAsync(url, token, param));

        public static async Task<string> PostAsync<TValue>(string url, string token, IEnumerable<KeyValuePair<string, TValue>> param)
            where TValue : HttpContent
        {
            using (var client = GetHttpClient(token))
            {
                if (param == null)
                    param = new Dictionary<string, TValue>();
                if (param.Select(p => p.Value).Any(item => item is StreamContent))
                {
                    using (var formData = new MultipartFormDataContent())
                    {
                        foreach (var item in param)
                            formData.Add(item.Value, item.Key);
                        using (var res = await client.PostAsync(url, formData))
                            return CheckForError(await res.Content.ReadAsStringAsync());
                    }
                }
                else
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    var items = new Dictionary<string, string>();
                    foreach (var item in param)
                        items.Add(item.Key, await item.Value.ReadAsStringAsync());
                    using (var formData = new FormUrlEncodedContent(items))
                    using (var res = await client.PostAsync(url, formData))
                        return CheckForError(await res.Content.ReadAsStringAsync());
                }
            }
        }



        public static async Task<string> DeleteAsync(string url, string token)
        {
            using (var client = GetHttpClient(token))
            using (var response = await client.SendAsync(new HttpRequestMessage(new HttpMethod("DELETE"), url)))
                return CheckForError(await response.Content.ReadAsStringAsync());
        }

        public static async Task<string> PatchAsync<TValue>(string url, string token, IEnumerable<KeyValuePair<string, TValue>> param)
            where TValue : HttpContent
        {
            using (var formData = new MultipartFormDataContent())
            {
                foreach (var item in param)
                {
                    if (item.Value is StreamContent)
                        formData.Add(new StringContent(Convert.ToBase64String(await item.Value.ReadAsByteArrayAsync())), item.Key);
                    else
                        formData.Add(item.Value, item.Key);
                }
                using (var client = GetHttpClient(token))
                using (var response = await client.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), url) { Content = formData }))
                    return CheckForError(await response.Content.ReadAsStringAsync());
            }
        }

        private static string CheckForError(string json)
        {
            if (string.IsNullOrEmpty(json))
                return json;
            try
            {
                var jobj = JsonConvert.DeserializeObject<JObject>(json);
                if (jobj.TryGetValue("error", out JToken token))
                {
                    throw new MastodonException(token.Value<string>());
                }
            }
            catch (InvalidCastException e)
            {

            }
            return json;
        }
    }
}
