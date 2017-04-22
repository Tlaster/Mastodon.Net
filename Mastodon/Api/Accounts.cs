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
    public partial class Accounts : Base
    {
        public int Id { get; }

        public Accounts(string domain, string accessToken, int id) : base(domain, accessToken)
        {
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
        /// <param name="max_id">(optional) Get a list of following with ID less than or equal this value</param>
        /// <param name="since_id">(optional) Get a list of following with ID greater than this value</param>
        /// <returns>Returns an array of <see cref="AccountModel"/></returns>
        public async Task<ArrayModel<AccountModel>> Following(int max_id = 0, int since_id = 0)
        {
            return await Following(Domain, AccessToken, Id, max_id, since_id);
        }

        /// <summary>
        /// Getting an account's statuses
        /// </summary>
        /// <param name="max_id">(optional) Get a list of Statuses with ID less than or equal this value</param>
        /// <param name="since_id">(optional) Get a list of Statuses with ID greater than this value</param>
        /// <param name="only_media">(optional) Only return statuses that have media attachments</param>
        /// <param name="exclude_replies">(optional) Skip statuses that reply to other statuses</param>
        /// <returns>Returns an array of <see cref="StatusModel"/></returns>
        public async Task<ArrayModel<StatusModel>> Statuses(int max_id = 0, int since_id = 0, bool only_media = false, bool exclude_replies = false)
        {
            return await Statuses(Domain, AccessToken, Id, max_id, since_id, only_media, exclude_replies);
        }

        /// <summary>
        /// Following an account
        /// </summary>
        /// <param name="id">Account Id</param>
        /// <returns>Returns the target account's <see cref="RelationshipModel"/></returns>
        public async Task<RelationshipModel> Follow(int id)
        {
            return await Follow(Domain, AccessToken, id);
        }

        /// <summary>
        /// Unfollowing an account
        /// </summary>
        /// <param name="id">Account Id</param>
        /// <returns>Returns the target account's <see cref="RelationshipModel"/></returns>
        public async Task<RelationshipModel> UnFollow(int id)
        {
            return await UnFollow(Domain, AccessToken, id);
        }


        /// <summary>
        /// Blocking an account
        /// </summary>
        /// <param name="id">Account Id</param>
        /// <returns>Returns the target account's <see cref="RelationshipModel"/></returns>
        public async Task<RelationshipModel> Block(int id)
        {
            return await Block(Domain, AccessToken, id);
        }

        /// <summary>
        /// Unblocking  an account
        /// </summary>
        /// <param name="id">Account Id</param>
        /// <returns>Returns the target account's <see cref="RelationshipModel"/></returns>
        public async Task<RelationshipModel> UnBlock(int id)
        {
            return await UnBlock(Domain, AccessToken, id);
        }



        /// <summary>
        /// Muting an account
        /// </summary>
        /// <param name="id">Account Id</param>
        /// <returns>Returns the target account's <see cref="RelationshipModel"/></returns>
        public async Task<RelationshipModel> Mute(int id)
        {
            return await Mute(Domain, AccessToken, id);
        }

        /// <summary>
        /// Unmuting   an account
        /// </summary>
        /// <param name="id">Account Id</param>
        /// <returns>Returns the target account's <see cref="RelationshipModel"/></returns>
        public async Task<RelationshipModel> UnMute(int id)
        {
            return await UnMute(Domain, AccessToken, id);
        }

        /// <summary>
        /// Getting an account's relationships
        /// </summary>
        /// <param name="id">(can be array) Account IDs</param>
        /// <returns>Returns an array of <see cref="RelationshipModel"/> of the current user to a list of given accounts</returns>
        public async Task<ArrayModel<RelationshipModel>> Relationships(params int[] id)
        {
            return await Relationships(Domain, AccessToken, id);
        }

        /// <summary>
        /// Searching for accounts
        /// </summary>
        /// <param name="q">What to search for</param>
        /// <param name="limit">Maximum number of matching accounts to return (default: 40)</param>
        /// <returns>Returns an array of matching <see cref="AccountModel"/>. Will lookup an account remotely if the search term is in the username@domain format and not yet in the database</returns>
        public async Task<ArrayModel<AccountModel>> Search(string q, int limit = 40)
        {
            return await Search(Domain, AccessToken, q, limit);
        }
    }
}
