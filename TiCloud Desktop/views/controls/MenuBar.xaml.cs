using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;
using Button = System.Windows.Controls.Button;
using Brushes = System.Windows.Media.Brushes;

//TODO: Dodać animacje ramki, dodać inny kolor nie aktywnych ikon

namespace TiCloud_Desktop.views.controls
{
    /// <summary>
    /// Logika interakcji dla klasy MenuBar.xaml
    /// </summary>
    public partial class MenuBar : System.Windows.Controls.UserControl
    {
        private static Button ActiveButtonBorder { get; set; }

        public MenuBar()
        {
            InitializeComponent();

            ActiveButtonBorder = HomeButton;
        }

        private void BorderFromSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActiveButtonBorder != null)
            {
                ActiveButtonBorder.BorderBrush = Brushes.Transparent; // lub inny domyślny kolor
                ActiveButtonBorder.MouseEnter += Button_MouseEnter;
                ActiveButtonBorder.MouseLeave += Button_MouseLeave;
            }


            Button button = (Button)sender;

            Debug.WriteLine($"{button.Name}");

            button.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF2541B"));
            button.MouseEnter += Button_MouseLeave;
            ActiveButtonBorder = button;

            SetBorderBrushForActiveButton(button);

            //Tu dodajemy nowe lokalizacje przycisków
            if (button.Name == "HomeButton")
            {
                AnimationBorder.Margin = new Thickness(12, 82, 12, 528);
            }
            if (button.Name == "DatabaseButton") {
                AnimationBorder.Margin= new Thickness(12, 142, 12, 468);
            }
  

        }


        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7FF2541B"));
        }

        private void Button_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00F9641B"));

        }

        private void SetBorderBrushForActiveButton(Button button)
        {
            // Kolor BorderBrush dla aktywnego przycisku po kliknięciu
            button.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00cccfd2"));
        }

        //TODO: dodać tu sprawdzenie czy liczony jest czas, jeśli tak to zwijamy do zasobnika albo wyswietlamy okno dialogowe czy chcemy zamknąć czy zwinąć
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Zamknięcie aplikacji
            System.Windows.Application.Current.Shutdown();
        }
    }
}
