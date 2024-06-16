using System.ComponentModel;

namespace Homework
{
    public interface IStatPresenter : IPresenter, INotifyPropertyChanged
    {
        string StatName { get; set; }
        int StatValue { get; set; }
    }
}