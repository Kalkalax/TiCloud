using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TiCloud_Desktop.viewmodels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private object _currentViewModel;
        private string _activeViewModelName;

        public object CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;
                    OnPropertyChanged(nameof(CurrentViewModel));
                    // Ustaw nazwę aktywnego widoku
                    ActiveViewModelName = value?.GetType().Name;
                    //Debug.Print(ActiveViewModelName);
                }

            }
        }

        public string ActiveViewModelName
        {
            get => _activeViewModelName;
            private set
            {
                if (_activeViewModelName != value)
                {
                    _activeViewModelName = value;
                    OnPropertyChanged(nameof(ActiveViewModelName));
                }
            }
        }


        public RelayCommand ShowHomeCommand { get; }
        public RelayCommand ShowDatabaseCommand { get; }

        public MainWindowViewModel()
        {
            // Domyślnie ustaw HomeViewModel
            CurrentViewModel = new HomeViewModel();

            //ShowHomeCommand = new RelayCommand(ExecuteShowHome);
            //ShowDatabaseCommand = new RelayCommand(ExecuteShowDatabase);

            ShowHomeCommand = new RelayCommand(() => CurrentViewModel = new HomeViewModel());
            ShowDatabaseCommand = new RelayCommand(() => CurrentViewModel = new DatabaseViewModel());




        }

        //private void ExecuteShowHome()
        //{
        //    Debug.WriteLine("Home button clicked");
        //    CurrentViewModel = new HomeViewModel();
        //}

        //private void ExecuteShowDatabase()
        //{
        //    Debug.WriteLine("Database button clicked");
        //    CurrentViewModel = new DatabaseViewModel();
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
