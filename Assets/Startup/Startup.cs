using Cinemachine;
using UnityEngine;
using M27.Generator;
using M27.Tile;

namespace M27.Startup 
{
    public class Startup : MonoBehaviour
    {
        /*
        [SerializeField] private CinemachineVirtualCamera[] m_virtualCameras;
        [SerializeField] private CameraMovement m_cameraMovement;
        [SerializeField] private float m_cameraSpeed;
        */

        [SerializeField] private TileSet _tileSet;
        [SerializeField] private int _terrainSize;
        [SerializeField] private Transform _terrainOrigin;
        private TerrainGenerator _terrainGenerator;

        private void Start()
        {
            /*
            if (m_virtualCameras.Length == 0 || m_cameraMovement == null)
            {
                Debug.Log("Check startup settings");
                return;
            }

            m_cameraMovement.VirtualCameras = m_virtualCameras;
            m_cameraMovement.CameraSpeed = m_cameraSpeed;
            m_cameraMovement.Init();
            */

            _terrainGenerator = new TerrainGenerator(_tileSet, _terrainSize, _terrainOrigin);
            _terrainGenerator.GenerateTerrain();
        }


    }
}


