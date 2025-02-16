using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using TiCloud_Desktop.core.data;
using TiCloud_Desktop.core.data.models;
using TiCloud_Desktop.views.controls;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TiCloud_Desktop.viewmodels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private List<UpdateData> updates;

        public ObservableCollection<UpdateTileButton> UpdateTileButtons { get; } = new ObservableCollection<UpdateTileButton>();

        public event PropertyChangedEventHandler PropertyChanged;

        public HomeViewModel()
        {
            AddUpdateTileButtonToList(); // Inicjalizacja przycisków zaraz po utworzeniu obiektu
        }


        public void AddUpdateTileButtonToList()
        {
            UpdateTileButtons.Clear(); // Czyścimy poprzednią zawartość

            updates = UpdateInfoManager.LoadAllUpdates();

            foreach (var update in updates)
            {

                // Dodajemy przycisk do kolekcji
                UpdateTileButton button = new()
                {
                    Margin = new Thickness(0, 0, 0, 10),
                    IconName = update.Icon?.Source,

                    Version = update.Version,
                    Text = update.Description,
                    Date = update.ReleaseDate,



                };

                UpdateTileButtons.Add(button);
            }
        }
    }
}