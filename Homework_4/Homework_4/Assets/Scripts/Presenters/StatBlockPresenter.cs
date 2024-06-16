using System.Collections.Generic;

namespace Homework
{
    public class StatBlockPresenter : IStatBlockPresenter
    {
        public IReadOnlyList<IStatPresenter> StatPresenters => statPresenters;
        private readonly List<IStatPresenter> statPresenters = new();

        public StatBlockPresenter(CharacterStatConfig[] characterStats)
        {
            foreach (var stat in characterStats)
            {
                statPresenters.Add(new StatPresenter(stat));
            }
        }
    }
}