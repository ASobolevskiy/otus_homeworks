using System.Collections.Generic;
using UnityEngine;

namespace Homework
{
    public class HeroPopupPresenter : IHeroPopupPresenter
    {
        public IUserInfoPresenter UserInfoPresenter { get; }
        public IStatBlockPresenter StatBlockPresenter { get; }
        public IExperiencePresenter ExperiencePresenter { get; }


        public HeroPopupPresenter(HeroInfo heroInfo)
        {
            UserInfoPresenter = new UserInfoPresenter(new UserInfo(heroInfo.UserInfo));
            StatBlockPresenter = new StatBlockPresenter(heroInfo.HeroStats);
            ExperiencePresenter = new HeroExperiencePresenter(heroInfo.HeroExperience);
        }
    }
}