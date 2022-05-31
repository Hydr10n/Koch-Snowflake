using Hydr10n;
using System;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace Koch_Snowflake
{
    public sealed partial class MainPage : Page
    {
        private void GenerateKochSnowflake()
        {
            KochSnowflake.Points = KochSnowflakeGenerator.Generate((uint)RepeatCount.Value, Math.Min(KochSnowflake.Width, KochSnowflake.Height) * 0.8, new Point(KochSnowflake.Width / 2, KochSnowflake.Height / 2 * 1.23));

            VertexCount.Text = KochSnowflake.Points.Count.ToString();
        }

        public MainPage()
        {
            InitializeComponent();

            GenerateKochSnowflake();
        }

        private void OK_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e) => GenerateKochSnowflake();

        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e) => KochSnowflake.StrokeThickness = 1 / (sender as ScrollViewer).ZoomFactor;
    }
}
