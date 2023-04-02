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
        
        private void Awake() =>
            _cinemachine = GetComponent<CinemachineVirtualCamera>();
    }
}

