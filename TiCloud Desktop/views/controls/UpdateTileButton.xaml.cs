using System.Diagnostics;
using System.Windows;
using TiCloud_Desktop.views.models;

namespace TiCloud_Desktop.views.controls
{
    /// <summary>
    /// Logika interakcji dla klasy UpdateTile.xaml
    /// </summary>
    public partial class UpdateTileButton : System.Windows.Controls.UserControl
    {


        
        public static readonly DependencyProperty IconNameProperty =
            DependencyProperty.Register(nameof(IconName), typeof(string), typeof(UpdateTileButton), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty VersionProperty =
            DependencyProperty.Register(nameof(Version), typeof(string), typeof(UpdateTileButton), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(UpdateTileButton), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty DateProperty =
            DependencyProperty.Register(nameof(Date), typeof(string), typeof(UpdateTileButton), new PropertyMetadata(string.Empty));

        public string IconName
        {
            get => (string)GetValue(IconNameProperty);
            set => SetValue(IconNameProperty, value);
        }

        public string Version
        {
            get => (string)GetValue(VersionProperty);
            set => SetValue(VersionProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public string Date
        {
            get => (string)GetValue(DateProperty);
            set => SetValue(DateProperty, value);
        }

            public UpdateTileButton()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Debug.WriteLine("SSSSSSSSSSSSS");
        }
    }
}
