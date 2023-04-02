using Cinemachine;
using UnityEngine;

namespace M27.Camera
{

    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class VirtualCamera : MonoBehaviour
    {
        public CameraType Type { get => _type; }
        [SerializeField]
        private CameraType _type;

        public CinemachineVirtualCamera Camera { get => _cinemachine; }
        private CinemachineVirtualCamera _cinemachine;

        public int Priority { get => _cinemachine.Priority; set => _cinemachine.Priority = value; }
        public float YRotation { get => _cinemachine.transform.rotation.eulerAngles.y; }
        public Quaternion Rotation { get => _cinemachine.transform.rotation; set => _cinemachine.transform.rotation = value; }
        
        private void Awake() =>
            _cinemachine = GetComponent<CinemachineVirtualCamera>();
    }
}

