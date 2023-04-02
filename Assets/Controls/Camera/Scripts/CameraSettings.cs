using UnityEngine;

namespace M27.Camera
{
    [CreateAssetMenu(menuName = "CameraSettings/Create New Settings", fileName = "New CameraSettings")]
    public class CameraSettings : ScriptableObject
    {
        public float CameraSpeed { get => _cameraSpeed; set => _cameraSpeed = value; }
        [SerializeField]
        private float _cameraSpeed;

        public float MouseSensitivity { get => _mouseSensitivity; set => _mouseSensitivity = value; }
        [SerializeField]
        private float _mouseSensitivity;
    }
}


