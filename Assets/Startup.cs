using Cinemachine;
using UnityEngine;

public class Startup : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] m_virtualCameras;   //Массив камер
    [SerializeField] private CameraMovement m_cameraMovement;               //Объект камеры
    [SerializeField] private float m_cameraSpeed;                           //Скорость камеры

    private void Start()
    {
        if (m_virtualCameras.Length == 0 || m_cameraMovement == null) 
        {
            Debug.Log("Check startup settings");
            return;
        }

        m_cameraMovement.VirtualCameras = m_virtualCameras;
        m_cameraMovement.CameraSpeed = m_cameraSpeed;
        m_cameraMovement.Init();
    }
}
