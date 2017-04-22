using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mastodon.Model;

namespace Mastodon.Api
{
    public partial class Media : Base
    {
        public Media(string domain, string accessToken) : base(domain, accessToken)
        {
        }

        /// <summary>
        /// Uploading a media attachment
        /// </summary>
        /// <param name="file">Media to be uploaded</param>
        /// <returns>Returns an <see cref="AttachmentModel"/> that can be used when creating a status</returns>
        public async Task<AttachmentModel> Uploading(byte[] file)
        {
            return await Uploading(Domain, AccessToken, file);
        }
    }
}
