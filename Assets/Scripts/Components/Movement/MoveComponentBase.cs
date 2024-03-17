using UnityEngine;

namespace ShootEmUp
{
    public abstract class MoveComponentBase : MonoBehaviour
    {
        public abstract void SetDirection(Vector2 direction);
    }
}