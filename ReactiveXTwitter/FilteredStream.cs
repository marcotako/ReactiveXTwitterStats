using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Events;
using Tweetinvi.Models;
using Tweetinvi.Streaming;

namespace ReactiveXTwitter
{
    public class FilteredStream
    {
        private readonly IFilteredStream _filteredStream;
        private readonly bool _isFake;

        private bool _stop;
        private IObservable<ITweet> _fakeTweets;

        public FilteredStream(string keyword, bool isFake = false)
        {            
            _isFake = isFake;
            _stop = true;

            if(_isFake)
            {
                SetupFakeObservable(keyword);
            }
            else
            {
                _filteredStream = Stream.CreateFilteredStream();
                _filteredStream.AddTrack(keyword);
            }
        }

        private void SetupFakeObservable(string keyword)
        {
            /*
             * Genera fake tweets con intervalos aletorios
             */
            var random = new Random();
            var variableInterval = Observable.Create<long>(async o =>
            {
                await Task.Delay(random.Next(2000, 5000));
                o.OnNext(0);
                o.OnCompleted();
                return Disposable.Empty;
            });

            _fakeTweets = variableInterval
            .SkipWhile(_ => _stop)
            .TakeWhile(_ => !_stop)
            .Repeat()
            .Delay(TimeSpan.FromMilliseconds(random.Next(0, 5000)))
            .Select(_ => new FakeTweet(random.Next(), $"{keyword} {random.Next()}", $"User{random.Next(0, 10)}"))
            .Synchronize();
        }

        public IObservable<ITweet> GetTweets()
        {
            if (_isFake)
                return _fakeTweets;

            return Observable.FromEventPattern<MatchedTweetReceivedEventArgs>(_filteredStream, nameof(_filteredStream.MatchingTweetReceived))
                .Select(ep => ep.EventArgs.Tweet);
        }

        public async Task StartStreamAsync()
        {
            if (_isFake)
            {
                _stop = false;
                return;
            }

            await _filteredStream.StartStreamMatchingAllConditionsAsync();
        }

        public void StopStream()
        {
            if (_isFake)
            {
                _stop = true;
                return;
            }
                

            _filteredStream.StopStream();
        }
    }
}
