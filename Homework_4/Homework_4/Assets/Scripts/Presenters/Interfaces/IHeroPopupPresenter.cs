using System.Collections.Generic;
using UnityEngine;

namespace Homework
{
    public interface IHeroPopupPresenter : IPresenter
    {
        IUserInfoPresenter UserInfoPresenter { get; }
        IStatBlockPresenter StatBlockPresenter { get; }
        
        IExperiencePresenter ExperiencePresenter { get; }
    }
}