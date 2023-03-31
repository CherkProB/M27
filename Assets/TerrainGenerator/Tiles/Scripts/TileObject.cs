using UnityEngine;

namespace M27.Tile
{
    public class TileObject : MonoBehaviour
    {
        [SerializeField]
        private int _size;
        public int Size { get { return _size; } }

        [SerializeField]
        private TileType _type;
        public TileType Type { get { return _type; } }
    }
}


