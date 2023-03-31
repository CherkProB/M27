using System.Collections.Generic;
using UnityEngine;

namespace M27.Tile
{
    [CreateAssetMenu(menuName = "TileSets/Create New TileSet", fileName = "New TileSet")]
    public class TileSet : ScriptableObject
    {
        [SerializeField]
        private TileObject[] _tilesPrefab;

        public TileObject[] CornerTiles 
        {
            get 
            {
                List<TileObject> _cornerTiles = new List<TileObject>();
                foreach (TileObject _tile in _tilesPrefab)
                    if (_tile.Type == TileType.Corner)
                        _cornerTiles.Add(_tile);

                return _cornerTiles.ToArray();
            }
        }
        public TileObject[] LineTiles 
        {
            get 
            {
                List<TileObject> _lineTiles = new List<TileObject>();
                foreach (TileObject _tile in _tilesPrefab)
                    if (_tile.Type == TileType.Line)
                        _lineTiles.Add(_tile);

                return _lineTiles.ToArray();
            }
        }
        public TileObject[] MainTiles 
        {
            get 
            {
                List<TileObject> _mainTiles = new List<TileObject>();
                foreach (TileObject _tile in _tilesPrefab)
                    if (_tile.Type == TileType.Main)
                        _mainTiles.Add(_tile);

                return _mainTiles.ToArray();
            }
        }
    }
}


