using System.ComponentModel;

namespace Homework
{
    public interface IExperiencePresenter : IPresenter, INotifyPropertyChanged
    {
        int CurrentLevel { get; set; }
        int CurrentExperience { get; set; }
        int RequiredExperience { get; set; }
        bool CanLevelUp { get; set; }

        void LevelUp();
    }
}