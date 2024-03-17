using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public sealed class InputSystem : MonoBehaviour
    {
        public event Action OnFire;
        public event Action<Vector2> OnMove;

        private void Update()
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
                return Vector2.left;
            return Input.GetKey(KeyCode.RightArrow) ? Vector2.right : Vector2.zero;
        }
    }
}