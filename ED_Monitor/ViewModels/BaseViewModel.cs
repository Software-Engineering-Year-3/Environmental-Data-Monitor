using CommunityToolkit.Mvvm.ComponentModel;

namespace ED_Monitor.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        string title = string.Empty;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
    }
}