using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;
using Tweetinvi.Models.DTO;
using Tweetinvi.Models.Entities;

namespace ReactiveXTwitter
{
    internal class FakeTweet : ITweet
    {
        private readonly IUser _fakeUser;
        private readonly long _id;
        private readonly DateTime _createdAt;

        public FakeTweet(long id, string text, string userName)
        {
            _fakeUser = new FakeUser(userName);
            Text = text;
            _id = id;
            _createdAt = DateTime.Now;
        }

        public DateTime CreatedAt => _createdAt;

        public string Text { get; set; }

        public string Prefix => throw new NotImplementedException();

        public string Suffix => throw new NotImplementedException();

        public string FullText { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int[] DisplayTextRange => throw new NotImplementedException();

        public int[] SafeDisplayTextRange => throw new NotImplementedException();

        public IExtendedTweet ExtendedTweet { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICoordinates Coordinates { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Source { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Truncated => throw new NotImplementedException();

        public int? ReplyCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long? InReplyToStatusId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string InReplyToStatusIdStr { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long? InReplyToUserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string InReplyToUserIdStr { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string InReplyToScreenName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IUser CreatedBy => _fakeUser;

        public ITweetIdentifier CurrentUserRetweetIdentifier => throw new NotImplementedException();

        public int[] ContributorsIds => throw new NotImplementedException();

        public IEnumerable<long> Contributors => throw new NotImplementedException();

        public int RetweetCount => throw new NotImplementedException();

        public ITweetEntities Entities => throw new NotImplementedException();

        public bool Favorited => throw new NotImplementedException();

        public int FavoriteCount => throw new NotImplementedException();

        public bool Retweeted => throw new NotImplementedException();

        public bool PossiblySensitive => throw new NotImplementedException();

        public Language Language => throw new NotImplementedException();

        public IPlace Place => throw new NotImplementedException();

        public Dictionary<string, object> Scopes => throw new NotImplementedException();

        public string FilterLevel => throw new NotImplementedException();

        public bool WithheldCopyright => throw new NotImplementedException();

        public IEnumerable<string> WithheldInCountries => throw new NotImplementedException();

        public string WithheldScope => throw new NotImplementedException();

        public ITweetDTO TweetDTO { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public DateTime TweetLocalCreationDate => throw new NotImplementedException();

        public List<IHashtagEntity> Hashtags => throw new NotImplementedException();

        public List<IUrlEntity> Urls => throw new NotImplementedException();

        public List<IMediaEntity> Media => throw new NotImplementedException();

        public List<IUserMentionEntity> UserMentions => throw new NotImplementedException();

        public List<ITweet> Retweets { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsRetweet => throw new NotImplementedException();

        public ITweet RetweetedTweet => throw new NotImplementedException();

        public int? QuoteCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public long? QuotedStatusId => throw new NotImplementedException();

        public string QuotedStatusIdStr => throw new NotImplementedException();

        public ITweet QuotedTweet => throw new NotImplementedException();

        public bool IsTweetPublished => throw new NotImplementedException();

        public bool IsTweetDestroyed => throw new NotImplementedException();

        public string Url => throw new NotImplementedException();

        public long Id => _id;

        public string IdStr => throw new NotImplementedException();

        public bool Destroy()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DestroyAsync()
        {
            throw new NotImplementedException();
        }

        public bool Equals(ITweet other)
        {
            throw new NotImplementedException();
        }

        public void Favorite()
        {
            throw new NotImplementedException();
        }

        public Task FavoriteAsync()
        {
            throw new NotImplementedException();
        }

        public IOEmbedTweet GenerateOEmbedTweet()
        {
            throw new NotImplementedException();
        }

        public Task<IOEmbedTweet> GenerateOEmbedTweetAsync()
        {
            throw new NotImplementedException();
        }

        public List<ITweet> GetRetweets()
        {
            throw new NotImplementedException();
        }

        public Task<List<ITweet>> GetRetweetsAsync()
        {
            throw new NotImplementedException();
        }

        public ITweet PublishRetweet()
        {
            throw new NotImplementedException();
        }

        public Task<ITweet> PublishRetweetAsync()
        {
            throw new NotImplementedException();
        }

        public void UnFavorite()
        {
            throw new NotImplementedException();
        }

        public Task UnFavoriteAsync()
        {
            throw new NotImplementedException();
        }

        public bool UnRetweet()
        {
            throw new NotImplementedException();
        }
    }
}
