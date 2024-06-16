using System.Collections.Generic;

namespace Homework
{
    public interface IStatBlockPresenter
    {
        IReadOnlyList<IStatPresenter> StatPresenters { get; }
    }
}