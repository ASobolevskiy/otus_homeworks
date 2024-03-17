using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public sealed class InputSystem : MonoBehaviour
    {
        public event Action OnFire;
        public float HorizontalDirection { get; private set; }

        [SerializeField]
        private GameObject character;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFire?.Invoke();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.HorizontalDirection = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.HorizontalDirection = 1;
            }
            else
            {
                this.HorizontalDirection = 0;
            }
        }
        
        private void FixedUpdate()
        {
            this.character.GetComponent<MoveComponent>().MoveByRigidbodyVelocity(new Vector2(this.HorizontalDirection, 0) * Time.fixedDeltaTime);
        }
    }
}