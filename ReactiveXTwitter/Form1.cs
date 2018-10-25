using System;
using System.Data;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tweetinvi;

namespace ReactiveXTwitter
{
    public partial class Form1 : Form
    {
        private static bool _isFake = false;

        // Obtain these values by creating a Twitter app at http://dev.twitter.com/
        private static string _consumerKey = "Drx3YJ2iikbBp6tPZ8e1r17R9";
        private static string _consumerSecret = "6E5BufINo8ECV6kyttNikxqaYy9DnYSbk8r98chA6qd3qjMuLx";
        private static string _token = "1053987166420959232-SoiWGIbc5UKHOhzjg1sp5y1X0l0hE0";
        private static string _tokenSecret = "FeZffklrrRC6q3NYlv42Rb8UKJPUrLipn8NOW3obUp2xD";

        private FilteredStream _beReactiveXMyFriendfilteredStream;
        private FilteredStream _dotnetmalagaFilteredStream;
        private CancellationTokenSource _cancellationTokenSource;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             * Descomentar para usar fake tweets (para testeo sin conexión a internet)
             */
            //_isFake = true;

            if (!_isFake)
                Auth.SetUserCredentials(_consumerKey, _consumerSecret, _token, _tokenSecret);

            /*
             * Creamos el flujo de tweets para "BeReactiveXMyFriend" y devolvemos un observable de tweets
             */
            _beReactiveXMyFriendfilteredStream = new FilteredStream("BeReactiveXMyFriend", _isFake);
            var beReactiveXMyFriendTweets = _beReactiveXMyFriendfilteredStream.GetTweets();

            /*
             * Creamos el flujo de tweets para "DotNetMalaga" y devolvemos un observable de tweets
             */
            _dotnetmalagaFilteredStream = new FilteredStream("DotNetMalaga2018", _isFake);
            var dotNetMalagaTweets = _dotnetmalagaFilteredStream.GetTweets();

            /*
             * Mezclamos los dos flujos en uno quitando los tweets repetidos ya que un mismo tweet podría 
             * entrar por los dos flujos si contiene las dos palabras clave
             */
            var allTweets = beReactiveXMyFriendTweets
                .Merge(dotNetMalagaTweets)
                //.Log(this.txtLog, "Merge")
                .Distinct(t => t.Id);

            /*
             * Usamos el mismo cancellation token para todas las suscripciones
             */
            _cancellationTokenSource = new CancellationTokenSource();

            /*
             * Mostramos los tweets sin más
             */
            allTweets
                .SubscribeToTextControl(this.txtTweets, t => $"{t.Text} - {t.CreatedBy.Name}", _cancellationTokenSource.Token);

            /*
             * Calculamos los tweets por segundo
             */
            allTweets
                .Buffer(TimeSpan.FromSeconds(1))
                .Select(b => b.Count)
                .DistinctUntilChanged() //Solo mostramos cada cambio de valor
                .Log(this.txtLog, "Tweets Por Segundos")
                .SubscribeToTextControl(this.txtTPS, tps => tps.ToString(), _cancellationTokenSource.Token);

            /*
             * Calcula el número de tweets por usuario
             */
            allTweets
                .GroupBy(t => t.CreatedBy.Name)
                .SelectMany(
                    go => go.Scan(0,
                        (a, t) => a + 1),
                        (o, c) => new { User = o.Key, MessageCount = c })
                .SubscribeToTextControl(this.txtUsers, x => $"{x.User} ({x.MessageCount})", _cancellationTokenSource.Token);

            /*
             * Calcula el número de total de tweets
             */
            allTweets
                .Scan(0, (a, t) => a + 1)
                .Log(this.txtLog, "Total Tweets")
                .SubscribeToTextControl(this.txtTotalTweets, x => x.ToString(), _cancellationTokenSource.Token);

            /*
             * Calcula el número de total de tweets con DotNetMalaga
             */
            dotNetMalagaTweets
                .Scan(0, (a, t) => a + 1)
                .Log(this.txtLog, "Total Tweets DotNetMalaga")
                .SubscribeToTextControl(this.txtTweetsDNM, x => x.ToString(), _cancellationTokenSource.Token);

            /*
             * Calcula el número de total de tweets con BeReactiveXMyFriend
             */
            beReactiveXMyFriendTweets
                .Scan(0, (a, t) => a + 1)
                .Log(this.txtLog, "Total Tweets BeReactiveXMyFriend")
                .SubscribeToTextControl(this.txtTweetsBRXMF, x => x.ToString(), _cancellationTokenSource.Token);

            /*
             * Calcula el número de veces en el que llegan dos tweets, uno con BeReactiveXMyFriend y el otro con DotNetMalaga
             * cada segundo
             */
            var timeFrame = Observable.Interval(TimeSpan.FromSeconds(1));
            dotNetMalagaTweets
                .Join(beReactiveXMyFriendTweets,
                    dnmt => timeFrame,
                    brxmft => timeFrame,        
                    (dnmt, brxmft) => new { DotNetMalagaTweet = dnmt, BeReactiveXMyFriendTweet = brxmft })
                .Select(x => $"{x.DotNetMalagaTweet.CreatedAt.ToShortTimeString()} - {x.BeReactiveXMyFriendTweet.CreatedAt.ToShortTimeString()}")
                .Log(this.txtLog, "Total veces DNM-BRMF tweets en el mismo segundo")
                .Scan(0, (a, t) => a + 1)                
                .SubscribeToTextControl(this.txtTotalDNM_BRMFPerSeconds, x => x.ToString(), _cancellationTokenSource.Token);

            /*
             * Calcula el número de tweets con BeReactiveXMyFriend y DotNetMalaga en el mismo tweet
             */
            dotNetMalagaTweets
                .Where(t => t.Text.ToUpper().Contains("BEREACTIVEXMYFRIEND"))
                .Merge(beReactiveXMyFriendTweets
                    .Where(t => t.Text.ToUpper().Contains("DOTNETMALAGA2018")))
                .Distinct(t => t.Id) //El mismo tweet entra por los dos flujos
                .Scan(0, (a, t) => a + 1)
                .Log(this.txtLog, "Número de tweets con DNM-BRMF")
                .SubscribeToTextControl(this.txtTweetsDNM_BRXMF, x => x.ToString(), _cancellationTokenSource.Token);

            /*
             * Calcula el tiempo medio entre tweets en segundos
             */
            allTweets
                .TimeInterval()                
                .Scan(new Accumulator { Acc = 0, Count = 0 },
                    (a, ti) => {
                        a.Acc += ti.Interval.Milliseconds;
                        a.Count++;
                        return a;
                    })
                .Select(a => ((decimal)a.Acc / (decimal)a.Count) / 1000)
                .Log(this.txtLog, "Tiempo medio entre tweets")
                .SubscribeToTextControl(this.txtAvgTimeBetweenTweets, x => x.ToString(), _cancellationTokenSource.Token);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cancellationTokenSource.Cancel();
            _dotnetmalagaFilteredStream.StopStream();
            _beReactiveXMyFriendfilteredStream.StopStream();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Task.Run(async () => await _beReactiveXMyFriendfilteredStream.StartStreamAsync());
            Task.Run(async () => await _dotnetmalagaFilteredStream.StartStreamAsync());
            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _dotnetmalagaFilteredStream.StopStream();
            _beReactiveXMyFriendfilteredStream.StopStream();
            this.btnStart.Enabled = true;
            this.btnStop.Enabled = false;
        }
    }
}
