using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReactiveXTwitter
{
    public static class Extensions
    {
        public static IObservable<T> Log<T>(this IObservable<T> observable, TextBox textBox, string msg = "")
        {
            return observable
                .ObserveOn(textBox)
                .Do(
                x => textBox.AppendText($"{msg} - OnNext({x}) @ {DateTime.Now.ToString("O")}{Environment.NewLine}"),
                ex =>
                {
                    textBox.AppendText($"{msg} - OnError:");
                    textBox.AppendText($"\t {ex}{Environment.NewLine}");
                },
                () => textBox.AppendText($"{msg} - OnCompleted() @ {DateTime.Now.ToString("O")}{Environment.NewLine}"));
        }

        public static void SubscribeToTextControl<T>(this IObservable<T> observable, TextBox textBox, Func<T, string> textSelector, CancellationToken token)
        {
            observable
                .ObserveOn(textBox)
                .Subscribe(o => 
                {
                    if (!textBox.Multiline)
                        textBox.Text = textSelector(o);
                    else
                        textBox.AppendText($"{textSelector(o)}{Environment.NewLine}");
                }, token);
        }
    }
}
