using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace M27.Camera 
{
    public class OrthogonalCameraBehaviour : BaseCameraBehaviour
    {
        public override void OnMove(InputValue input)
        {
            Vector2 _inputVector = input.Get<Vector2>();
            _moveDirection = new Vector3(_inputVector.x, 0, _inputVector.y);
        }

        public override void OnLookAround(InputValue input) 
        {
            Vector2 _inputVector = input.Get<Vector2>();
            _moveDirection = _isLooking ? new Vector3(_inputVector.x, 0, _inputVector.y) : Vector3.zero;
        }
    }
}

