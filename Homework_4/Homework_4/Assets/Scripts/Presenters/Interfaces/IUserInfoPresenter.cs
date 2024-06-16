using UnityEngine;

namespace Homework
{
    public interface IUserInfoPresenter : IPresenter
    {
        string Name { get; set; }
        string Description { get; set; }
        Sprite Icon { get; set; }
    }
}