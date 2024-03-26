using UnityEngine;

namespace ShootEmUp
{
    public abstract class MoveComponentBase : MonoBehaviour,
        Listeners.IGameListener
    {
        public abstract void SetDirection(Vector2 direction);
    }
}