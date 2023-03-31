using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class CameraMovement : MonoBehaviour
{
    /*
    /// <summary>
    /// Массив камер, между которыми переключается пользователь
    /// </summary>
    public CinemachineVirtualCamera[] VirtualCameras { set { m_virtualCameras = value; } }
    private CinemachineVirtualCamera[] m_virtualCameras;
    private int m_currentCamera;

    /// <summary>
    /// Скорость перемещения камеры
    /// </summary>
    public float CameraSpeed { set { m_cameraSpeed = value; } }
    private float m_cameraSpeed;
    private Vector2 m_cameraMoveVector;    

    /// <summary>
    /// Инициализация
    /// </summary>
    public void Init()
    {
        SetActiveCamera(m_currentCamera = 0);
    }

    /// <summary>
    /// Метод, вызываемый при срабатывании события перемещения
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context) =>
        m_cameraMoveVector = new Vector2(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y);

    /// <summary>
    /// Метод, вызываемый при срабатывании события изменения камеры
    /// </summary>
    /// <param name="context"></param>
    public void OnChange(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        m_currentCamera = (m_currentCamera + 1) < m_virtualCameras.Length ? m_currentCamera + 1 : 0;
        SetActiveCamera(m_currentCamera);
    }

    /// <summary>
    /// Метод, вызываемый при срабатывании события перемещения мышкой
    /// </summary>
    /// <param name="context"></param>
    public void OnMouseMove(InputAction.CallbackContext context) 
    {
        if (Mouse.current.leftButton.isPressed)
            m_cameraMoveVector = context.ReadValue<Vector2>() * -0.5f;
        if (Mouse.current.leftButton.wasReleasedThisFrame)
            m_cameraMoveVector = Vector2.zero;
    }

    /// <summary>
    /// Смена активной камеры
    /// </summary>
    /// <param name="number"></param>
    private void SetActiveCamera(int number)
    {
        foreach (CinemachineVirtualCamera cam in m_virtualCameras)
            cam.Priority = 0;

        m_virtualCameras[number].Priority = 1;
    }

    /// <summary>
    /// Апдате
    /// </summary>
    private void Update()
    {
        Vector3 moveVector = new Vector3(m_cameraMoveVector.x, 0, m_cameraMoveVector.y);

        //Transform 1 cam
        //m_virtualCameras[m_currentCamera].transform.position += moveVector * m_cameraSpeed * Time.deltaTime;

        //Transform all cams
        foreach (CinemachineVirtualCamera cam in m_virtualCameras)
            cam.transform.position += moveVector * m_cameraSpeed * Time.deltaTime;
    }
    */
}
