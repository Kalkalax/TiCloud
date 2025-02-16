using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using TiCloud_Desktop.core.data;
using TiCloud_Desktop.views.controls;

namespace TiCloud_Desktop.viewmodels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<UpdateTileButton> UpdateTileButtons { get; } = new ObservableCollection<UpdateTileButton>();

        public event PropertyChangedEventHandler PropertyChanged;

        public HomeViewModel()
        {
            AddUpdateTileButtonToList(); // Inicjalizacja przycisków zaraz po utworzeniu obiektu
        }


        public void AddUpdateTileButtonToList()
        {
            UpdateTileButtons.Clear(); // Czyścimy poprzednią zawartość

            int count = UpdateInfoManager.CountUpdateFiles(); // Pobranie liczby aktualizacji

            for (int i = 0; i < count; i++) // Użycie 'count' jako wartości początkowej
            {
                // Dodajemy przycisk do kolekcji
                UpdateTileButton button = new()
                {
                    Margin = new Thickness(0, 0, 0, 10),
                    Version = i.ToString(),   // Ustawienie wersji
                };

                UpdateTileButtons.Add(button);
            }
        }
    }
}