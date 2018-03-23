using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Mastodon.Common;
using Mastodon.Model;

namespace Mastodon.Api
{
    public class Media
    {
        /// <summary>
        ///     Uploading a media attachment
        /// </summary>
        /// <param name="domain">Mastodon instance domain</param>
        /// <param name="token">AccessToken</param>
        /// <param name="file">Media to be uploaded</param>
        /// <returns>Returns an <see cref="AttachmentModel" /> that can be used when creating a status</returns>
        public static async Task<Attachment> Uploading(string domain, string token, byte[] file)
        {
            return await HttpHelper.PostAsync<Attachment, StreamContent>(
                $"{HttpHelper.HTTPS}{domain}{Constants.MediaUploading}", token, new[]
                {
                    (nameof(file), new StreamContent(new MemoryStream(file)))
                });
        }
    }
}