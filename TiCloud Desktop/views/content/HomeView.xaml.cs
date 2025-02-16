using System.Windows;
using System.Windows.Controls;
using TiCloud_Desktop.viewmodels;

namespace TiCloud_Desktop.views.content
{
    public partial class HomeView : System.Windows.Controls.UserControl
    {
        public HomeView()
        {
            InitializeComponent();

        }
        // Możesz usunąć metodę UpdateTile_Loaded, jeśli nie jest potrzebna
        private void HomeView_Loaded(object sender, RoutedEventArgs e)
        {
            // Po załadowaniu widoku, wywołujemy metodę z ViewModelu
            
        }
    }
}
