using M27.Camera;
using M27.Generator;
using M27.Tile;
using UnityEngine;

namespace M27.Startup
{
    public class Startup : MonoBehaviour
    {
        [Header("TerrainGenerator")]
        [SerializeField] private TileSet _tileSet;
        [SerializeField] private int _terrainSize;
        [SerializeField] private Transform _terrainOrigin;
        private TerrainGenerator _terrainGenerator;

        [Header("CameraSettings")]
        [SerializeField] private CameraSettings _cameraSettings;
        [SerializeField] private CameraMovementManager _cameraManager;
        [SerializeField] private VirtualCamera[] _virtualCameras;

        private void Start()
        {
            _terrainGenerator = new TerrainGenerator(_tileSet, _terrainSize, _terrainOrigin);
            _terrainGenerator.GenerateTerrain();

            _cameraManager.Settings = _cameraSettings;
            _cameraManager.VirtualCameras = _virtualCameras;
            _cameraManager.SetActiveCamera(0);
        }


    }
}


