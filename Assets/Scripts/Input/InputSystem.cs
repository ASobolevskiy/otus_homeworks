using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputSystem : MonoBehaviour,
        Listeners.IUpdateListener
    {
        public event Action OnFire;
        public event Action<Vector2> OnMove;

        public void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFire?.Invoke();
            }
            OnMove?.Invoke(GetDirection());
        }

        private Vector2 GetDirection()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                return Vector2.left;
            }

            return Input.GetKey(KeyCode.RightArrow) ? Vector2.right : Vector2.zero;
        }
    }
}