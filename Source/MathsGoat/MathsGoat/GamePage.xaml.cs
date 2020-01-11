using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.SpeechRecognition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MathsGoat
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        private SpeechRecognizer m_speechRecognizer;

        public GamePage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            m_speechRecognizer = new SpeechRecognizer();

            await m_speechRecognizer.CompileConstraintsAsync();

            m_speechRecognizer.ContinuousRecognitionSession.ResultGenerated += (s, arg) =>
            {
                Console.WriteLine(arg.Result.Text);
            };

            while (m_speechRecognizer.State != SpeechRecognizerState.Idle)
            {

            }

            await m_speechRecognizer.ContinuousRecognitionSession.StartAsync();
        }

        protected override async void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            var continiousSession = m_speechRecognizer.ContinuousRecognitionSession;
            await continiousSession.StopAsync();

            m_speechRecognizer = null;
        }

        private async void TestSpeech(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
