using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace M27.Camera
{
    [RequireComponent(typeof(PlayerInput))]
    public class CameraMovementManager : MonoBehaviour
    {
        public CameraSettings Settings { set => _settings = value; }
        private CameraSettings _settings;

        public VirtualCamera[] VirtualCameras { set => _virtualCameras = value; }
        private VirtualCamera[] _virtualCameras;
        private int _currentVirtualCamera;

        public BaseCameraBehaviour Behaviour { set => _behaviour = value; }
        private BaseCameraBehaviour _behaviour;

        public void OnChangeCamera()
        {
            _currentVirtualCamera = _currentVirtualCamera < _virtualCameras.Length - 1 ? _currentVirtualCamera + 1 : 0;
            SetActiveCamera(_currentVirtualCamera);
        }

        public void OnMove(InputValue input) =>
            _behaviour.OnMove(input);

        public void OnLookAround(InputValue input) =>
            _behaviour.OnLookAround(input);

        public void OnLookAroundToggle(InputValue input) 
        {
            _behaviour.OnLookAroundToggle(input);
            Cursor.lockState = _behaviour.IsLooking ? CursorLockMode.Locked : CursorLockMode.None;
        }

        private void Update()
        {
            if (_behaviour.MoveDirection != Vector3.zero)
                foreach (VirtualCamera _vc in _virtualCameras) 
                {
                    _vc.Camera.transform.position += _behaviour.MoveDirection * _settings.CameraSpeed * Time.deltaTime;

                    /*
                    float _camRotation = _vc.Camera.transform.rotation.eulerAngles.y;
                    _vc.Camera.transform.position += 
                        new Vector3(_behaviour.MoveDirection.x * Mathf.Cos(_camRotation * Mathf.Deg2Rad), 0, _behaviour.MoveDirection.z * Mathf.Sin(_camRotation * Mathf.Deg2Rad)) * _settings.CameraSpeed * Time.deltaTime;
                    */
                }

            if (_behaviour.RotationDirection != Vector3.zero)
                foreach (VirtualCamera _vc in _virtualCameras)
                {
                    Vector3 _currentQuat = _vc.Camera.transform.rotation.eulerAngles;
                    _currentQuat += _behaviour.RotationDirection * _settings.MouseSensitivity * Time.deltaTime;
                    _vc.Camera.transform.rotation = Quaternion.Euler(_currentQuat);

                    //check -180 - 180
                }

        }

        public void SetActiveCamera(int index)
        {
            if (index >= _virtualCameras.Length) return;
            _currentVirtualCamera = index;

            foreach (VirtualCamera _cam in _virtualCameras)
                _cam.Priority = 0;
            _virtualCameras[_currentVirtualCamera].Priority = 1;

            _behaviour = _virtualCameras[_currentVirtualCamera].Type == CameraType.ThirdPerson ? new ThirdPersonCameraBehaviour() : new OrthogonalCameraBehaviour();
            //switch - case if Type > 2
        }

    }
}
