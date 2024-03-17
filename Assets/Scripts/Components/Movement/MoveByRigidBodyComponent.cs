using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveByRigidBodyComponent : MoveComponentBase
    {
        [SerializeField]
        private new Rigidbody2D rigidbody2D;

        [SerializeField]
        private float speed = 5.0f;

        private Vector2 direction;

        public override void SetDirection(Vector2 direction)
        {
            this.direction = direction;
        }

        private void FixedUpdate()
        {
            var nextPosition = rigidbody2D.position + (speed * Time.fixedDeltaTime * direction);
            rigidbody2D.MovePosition(nextPosition);
        }
    }
}