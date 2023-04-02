using UnityEngine;
using UnityEngine.InputSystem;

namespace M27.Camera
{
    public abstract class BaseCameraBehaviour
    {
        public Vector3 MoveDirection => _moveDirection;
        protected Vector3 _moveDirection;

        public Vector3 RotationDirection => _rotationDirection;
        protected Vector3 _rotationDirection;

        public bool IsLooking => _isLooking;
        protected bool _isLooking;

        public virtual void OnLookAroundToggle(InputValue input) =>
            _isLooking = !IsLooking;

        public virtual void OnMove(InputValue input) { }
        public virtual void OnLookAround(InputValue input) { }
    }
}

