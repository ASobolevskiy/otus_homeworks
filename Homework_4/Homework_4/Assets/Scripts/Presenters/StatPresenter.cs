using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

namespace Homework
{
    public class StatPresenter : IStatPresenter, INotifyPropertyChanged
    {
        public string StatName { get; set; }

        private int statValue;
        public int StatValue
        {
            get => statValue;
            set
            {
                if (statValue != value)
                {
                    statValue = value;
                    OnPropertyChanged();
                }
            }
        }

        public StatPresenter(CharacterStatConfig statConfig)
        {
            StatName = statConfig.stat.Name;
            StatValue = statConfig.stat.Value;
            statConfig.stat.OnValueChanged += (val) => StatValue = val;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}