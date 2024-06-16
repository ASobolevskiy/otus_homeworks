using UnityEngine;

namespace Homework
{
    public class UserInfoPresenter : IUserInfoPresenter
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Sprite Icon { get; set; }

        public UserInfoPresenter(UserInfo userInfo)
        {
            Name = userInfo.Name;
            Description = userInfo.Description;
            Icon = userInfo.Icon;
        }
    }
}