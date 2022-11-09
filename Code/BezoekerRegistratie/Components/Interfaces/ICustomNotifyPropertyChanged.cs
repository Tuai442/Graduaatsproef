using System.ComponentModel;

namespace Components.Interfaces
{
    public interface ICustomNotifyPropertyChanged
    {
        event PropertyChangedEventHandler PropertyChanged;
    }
}