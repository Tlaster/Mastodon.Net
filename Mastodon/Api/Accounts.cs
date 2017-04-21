using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mastodon.Common;
using Mastodon.Model;

namespace Mastodon.Api
{
    public partial class Accounts
    {
        /// <summary>
        /// Mastodon instance domain
        /// </summary>
        public string Domain { get; }
        public string AccessToken { get; }
        public int Id { get; }

        public Accounts(string domain, string accessToken, int id)
        {
            Domain = domain;
            AccessToken = accessToken;
            Id = id;
        }

        /// <summary>
        /// Fetching an account
        /// </summary>
        /// <param name="id">Account Id</param>
        /// <returns><see cref="AccountModel"/></returns>
        public Task<AccountModel> Fetching(int id) => Fetching(Domain, id, AccessToken);

        /// <summary>
        /// Getting the current user
        /// </summary>
        /// <returns><see cref="AccountModel"/></returns>
        public async Task<AccountModel> VerifyCredentials() => await VerifyCredentials(Domain, AccessToken);

        /// <summary>
        /// Updating the current user
        /// </summary>
        /// <param name="display_name">The name to display in the user's profile</param>
        /// <param name="note">A new biography for the user</param>
        /// <param name="avatar">Byte array of the image file</param>
        /// <param name="header">Byte array of the image file</param>
        /// <returns></returns>
        public async Task UpdateCredentials(string display_name, string note, byte[] avatar, byte[] header)
        {
            await UpdateCredentials(Domain, AccessToken, display_name, note, avatar, header);
        }

        /// <summary>
        /// Getting an account's followers
        /// </summary>
        /// <param name="max_id">(optional) Get a list of followers with ID less than or equal this value</param>
        /// <param name="since_id">(optional) Get a list of followers with ID greater than this value</param>
        /// <param name="limit">(optional) Maximum number of accounts to get (Default 40, Max 80)</param>
        /// <returns>Returns an array of <see cref="AccountModel"/></returns>
        public async Task<ArrayModel<AccountModel>> Followers(int max_id = 0, int since_id = 0, int limit = 40)
        {
            return await Followers(Domain, AccessToken, max_id, since_id, limit);
        }


        /// <summary>
        /// Getting who account is following
        /// </summary>
        /// <param name="max_id">(optional) Get a list of followers with ID less than or equal this value</param>
        /// <param name="since_id">(optional) Get a list of followers with ID greater than this value</param>
        /// <returns>Returns an array of <see cref="AccountModel"/></returns>
        public async Task<ArrayModel<AccountModel>> Following(int max_id = 0, int since_id = 0)
        {
            return await Following(Domain, AccessToken, Id, max_id, since_id);
        }

    }
}
