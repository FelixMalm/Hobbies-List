using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Hobbies_List.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _newHobby;
        private string _selectedHobby;

        public ObservableCollection<string> Hobbies { get; set; }

        public string NewHobby
        {
            get => _newHobby;
            set
            {
                _newHobby = value;
                OnPropertyChanged();
            }
        }

        public string SelectedHobby
        {
            get => _selectedHobby;
            set
            {
                _selectedHobby = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public ICommand AddHobbyCommand { get; }
        public ICommand RemoveHobbyCommand { get; }

        public MainViewModel()
        {
            Hobbies = new ObservableCollection<string>
            {
                "Frodo",
                "Sam",
                "Merry"
            };
            AddHobbyCommand = new RelayCommand(AddHobby, CanAddHobby);
            RemoveHobbyCommand = new RelayCommand(RemoveHobby, CanRemoveHobby);
        }
                        
        private void AddHobby()
        {
            Hobbies.Add(NewHobby);
            NewHobby = string.Empty;
        }

        private bool CanAddHobby()
        {
            return !string.IsNullOrWhiteSpace(NewHobby);
        }

        private void RemoveHobby()
        {
            Hobbies.Remove(SelectedHobby);
        }

        private bool CanRemoveHobby()
        {
            return !string.IsNullOrEmpty(SelectedHobby);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
