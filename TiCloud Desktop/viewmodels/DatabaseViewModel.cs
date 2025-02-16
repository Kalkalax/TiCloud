using System.ComponentModel;
using System.Runtime.CompilerServices;

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
    }
}
