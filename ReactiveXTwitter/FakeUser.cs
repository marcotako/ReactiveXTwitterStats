using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;
using Tweetinvi.Models.DTO;
using Tweetinvi.Models.Entities;
using Tweetinvi.Parameters;

namespace ReactiveXTwitter
{
    internal class FakeUser : IUser
    {
        private readonly string _name;
        public FakeUser(string name)
        {
            _name = name;
        }

        public IUserDTO UserDTO { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IUserIdentifier UserIdentifier => throw new NotImplementedException();

        public string Name => _name;

        public string Description => throw new NotImplementedException();

        public ITweetDTO Status => throw new NotImplementedException();

        public DateTime CreatedAt => throw new NotImplementedException();

        public string Location => throw new NotImplementedException();

        public bool GeoEnabled => throw new NotImplementedException();

        public string Url => throw new NotImplementedException();

        public Language Language => throw new NotImplementedException();

        public int StatusesCount => throw new NotImplementedException();

        public int FollowersCount => throw new NotImplementedException();

        public int FriendsCount => throw new NotImplementedException();

        public bool Following => throw new NotImplementedException();

        public bool Protected => throw new NotImplementedException();

        public bool Verified => throw new NotImplementedException();

        public IUserEntities Entities => throw new NotImplementedException();

        public bool Notifications => throw new NotImplementedException();

        public string ProfileImageUrl => throw new NotImplementedException();

        public string ProfileImageUrlFullSize => throw new NotImplementedException();

        public string ProfileImageUrl400x400 => throw new NotImplementedException();

        public string ProfileImageUrlHttps => throw new NotImplementedException();

        public bool FollowRequestSent => throw new NotImplementedException();

        public bool DefaultProfile => throw new NotImplementedException();

        public bool DefaultProfileImage => throw new NotImplementedException();

        public int FavouritesCount => throw new NotImplementedException();

        public int ListedCount => throw new NotImplementedException();

        public string ProfileSidebarFillColor => throw new NotImplementedException();

        public string ProfileSidebarBorderColor => throw new NotImplementedException();

        public bool ProfileBackgroundTile => throw new NotImplementedException();

        public string ProfileBackgroundColor => throw new NotImplementedException();

        public string ProfileBackgroundImageUrl => throw new NotImplementedException();

        public string ProfileBackgroundImageUrlHttps => throw new NotImplementedException();

        public string ProfileBannerURL => throw new NotImplementedException();

        public string ProfileTextColor => throw new NotImplementedException();

        public string ProfileLinkColor => throw new NotImplementedException();

        public bool ProfileUseBackgroundImage => throw new NotImplementedException();

        public bool IsTranslator => throw new NotImplementedException();

        public bool ContributorsEnabled => throw new NotImplementedException();

        public int? UtcOffset => throw new NotImplementedException();

        public string TimeZone => throw new NotImplementedException();

        public IEnumerable<string> WithheldInCountries => throw new NotImplementedException();

        public string WithheldScope => throw new NotImplementedException();

        public List<long> FriendIds { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IUser> Friends { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<long> FollowerIds { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IUser> Followers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IUser> Contributors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IUser> Contributees { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<ITweet> Timeline { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<ITweet> Retweets { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<ITweet> FriendsRetweets { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<ITweet> TweetsRetweetedByFollowers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string IdStr { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ScreenName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<bool> BlockAsync()
        {
            throw new NotImplementedException();
        }

        public bool BlockUser()
        {
            throw new NotImplementedException();
        }

        public bool Equals(IUser other)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IUser> GetContributees(bool createContributeeList = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IUser>> GetContributeesAsync(bool createContributeeList = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IUser> GetContributors(bool createContributorList = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IUser>> GetContributorsAsync(bool createContributorList = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITweet> GetFavorites(int maximumNumberOfTweets = 40)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITweet> GetFavorites(IGetUserFavoritesParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ITweet>> GetFavoritesAsync(int maximumTweets = 40)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ITweet>> GetFavoritesAsync(IGetUserFavoritesParameters parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<long> GetFollowerIds(int maxFriendsToRetrieve = 5000)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<long>> GetFollowerIdsAsync(int maxFriendsToRetrieve = 5000)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IUser> GetFollowers(int maxFriendsToRetrieve = 250)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IUser>> GetFollowersAsync(int maxFriendsToRetrieve = 250)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<long> GetFriendIds(int maxFriendsToRetrieve = 5000)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<long>> GetFriendIdsAsync(int maxFriendsToRetrieve = 5000)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IUser> GetFriends(int maxFriendsToRetrieve = 250)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IUser>> GetFriendsAsync(int maxFriendsToRetrieve = 250)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITwitterList> GetOwnedLists(int maximumNumberOfListsToRetrieve)
        {
            throw new NotImplementedException();
        }

        public Stream GetProfileImageStream(ImageSize imageSize = ImageSize.normal)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> GetProfileImageStreamAsync(ImageSize imageSize = ImageSize.normal)
        {
            throw new NotImplementedException();
        }

        public IRelationshipDetails GetRelationshipWith(IUserIdentifier user)
        {
            throw new NotImplementedException();
        }

        public Task<IRelationshipDetails> GetRelationshipWithAsync(IUserIdentifier user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITwitterList> GetSubscribedLists(int maximumNumberOfListsToRetrieve = 1000)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITweet> GetUserTimeline(int maximumNumberOfTweets = 40)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITweet> GetUserTimeline(IUserTimelineParameters timelineParameters)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ITweet>> GetUserTimelineAsync(int maximumTweet = 40)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ITweet>> GetUserTimelineAsync(IUserTimelineParameters timelineParameters)
        {
            throw new NotImplementedException();
        }

        public bool ReportUserForSpam()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UnBlockAsync()
        {
            throw new NotImplementedException();
        }

        public bool UnBlockUser()
        {
            throw new NotImplementedException();
        }
    }
}
