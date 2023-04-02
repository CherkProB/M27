using M27.Tile;
using UnityEngine;

namespace M27.Generator
{
    public class TerrainGenerator
    {
        private readonly TileSet _tileSet;
        public int FieldSize { set => _fieldSize = value; }
        private int _fieldSize;
        public Transform TerrainOrigin {set => _terrainOrigin = value;  }
        private Transform _terrainOrigin;

        public GameObject[,] Field { get => _field; }
        private GameObject[,] _field;

        public TerrainGenerator(TileSet tileSet, int fieldSize = 5, Transform terrainOrigin = null)
        {
            _tileSet = tileSet;
            _fieldSize = fieldSize;
            _terrainOrigin = terrainOrigin;
        }

        public void GenerateTerrain()
        {
            if (_fieldSize < 1)
                _fieldSize = 2;

            _field = new GameObject[_fieldSize, _fieldSize];

            for (int i = 0; i < _fieldSize; i++)
                for (int j = 0; j < _fieldSize; j++)
                {
                    TileObject _tile = _tileSet.MainTiles[0];
                    Vector3 _tilePosition = Vector3.zero;
                    Quaternion _tileRotation = Quaternion.identity;
                    int _tileIndex = 0;

                    if (i == 0 && j == 0)
                    {
                        _tileIndex = Random.Range(0, _tileSet.CornerTiles.Length);

                        _tile = _tileSet.CornerTiles[_tileIndex];
                        _tilePosition = Vector3.zero;
                        _tileRotation = Quaternion.identity;
                    }
                    else if (i == 0 && j == _fieldSize - 1)
                    {
                        _tileIndex = Random.Range(0, _tileSet.CornerTiles.Length);

                        _tile = _tileSet.CornerTiles[_tileIndex];
                        _tilePosition = Vector3.right * _tile.Size * j;
                        _tileRotation = Quaternion.Euler(Vector3.up * 90);
                    }
                    else if (i == _fieldSize - 1 && j == 0)
                    {
                        _tileIndex = Random.Range(0, _tileSet.CornerTiles.Length);

                        _tile = _tileSet.CornerTiles[_tileIndex];
                        _tilePosition = Vector3.back * _tile.Size * i;
                        _tileRotation = Quaternion.Euler(Vector3.up * 270);

                    }
                    else if (i == _fieldSize - 1 && j == _fieldSize - 1)
                    {
                        _tileIndex = Random.Range(0, _tileSet.CornerTiles.Length);

                        _tile = _tileSet.CornerTiles[_tileIndex];
                        _tilePosition = (Vector3.back * i + Vector3.right * j) * _tile.Size;
                        _tileRotation = Quaternion.Euler(Vector3.up * 180);
                    }
                    else if (i == 0)
                    {
                        _tileIndex = Random.Range(0, _tileSet.LineTiles.Length);

                        _tile = _tileSet.LineTiles[_tileIndex];
                        _tilePosition = Vector3.right * _tile.Size * j;
                        _tileRotation = Quaternion.Euler(Vector3.up * 90);
                    }
                    else if (i == _fieldSize - 1)
                    {
                        _tileIndex = Random.Range(0, _tileSet.LineTiles.Length);

                        _tile = _tileSet.LineTiles[_tileIndex];
                        _tilePosition = (Vector3.back * i + Vector3.right * j) * _tile.Size;
                        _tileRotation = Quaternion.Euler(Vector3.up * 270);
                    }
                    else if (j == 0)
                    {
                        _tileIndex = Random.Range(0, _tileSet.LineTiles.Length);

                        _tile = _tileSet.LineTiles[_tileIndex];
                        _tilePosition = Vector3.back * _tile.Size * i;
                        _tileRotation = Quaternion.identity;
                    }
                    else if (j == _fieldSize - 1)
                    {
                        _tileIndex = Random.Range(0, _tileSet.LineTiles.Length);

                        _tile = _tileSet.LineTiles[_tileIndex];
                        _tilePosition = (Vector3.back * i + Vector3.right * j) * _tile.Size;
                        _tileRotation = Quaternion.Euler(Vector3.up * 180);
                    }
                    else
                    {
                        _tileIndex = Random.Range(0, _tileSet.MainTiles.Length);

                        _tile = _tileSet.MainTiles[_tileIndex];
                        _tilePosition = (Vector3.back * i + Vector3.right * j) * _tile.Size;
                        _tileRotation = Quaternion.Euler(Vector3.up * Random.Range(0, 4) * 90);
                    }

                    _field[i, j] = GameObject.Instantiate(_tile.gameObject, _tilePosition, _tileRotation, _terrainOrigin);
                }
        }

        public void DestroyTerrain()
        {
            for (int i = 0; i < _fieldSize; i++)
                for (int j = 0; j < _fieldSize; j++)
                    GameObject.Destroy(_field[i, j]);
        }
    }

}

