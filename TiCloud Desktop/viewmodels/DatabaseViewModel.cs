using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using TiCloud.Core.Database;
using TiCloud.Core.Database.Models;
using TiCloud_Desktop.core.data;
using TiCloud_Desktop.views.controls;

namespace TiCloud_Desktop.viewmodels
{
    public class DatabaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Tutaj dodaj właściwości i logikę dla DatabaseView

        List<Project> projects;

        public ObservableCollection<DatabaseProjectsTile> DatabaseProjectsTiles { get; } = new ObservableCollection<DatabaseProjectsTile>();

        public DatabaseViewModel()
        {
            AddatabaseProjectTileToList(); // Inicjalizacja przycisków zaraz po utworzeniu obiektu
        }

        public void AddatabaseProjectTileToList()
        {
            DatabaseProjectsTiles.Clear(); // Czyścimy poprzednią zawartość

            List<Project> projects = DatabaseManager.GetAllProjects().ToList();


            projects.ForEach(p => Debug.WriteLine($"{p.ProjectName}, ID:{p.ProjectID}"));

            //updates = UpdateInfoManager.LoadAllUpdates();

            foreach (var project in projects)
            {

                // Dodajemy przycisk do kolekcji
                DatabaseProjectsTile button = new()
                {
                 
                    ProjectName = project.ProjectName,
                    ProjectID = project.ProjectID.ToString(),


                };

                DatabaseProjectsTiles.Add(button);
            }
        }

    }
}
