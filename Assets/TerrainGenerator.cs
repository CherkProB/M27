using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tiles;
    [SerializeField]
    private GameObject origin;

    [SerializeField]
    private int m_fieldSize;
    [SerializeField]
    private int m_tileSize;

    private GameObject[,] field;

    private void Start()
    {
        m_fieldSize += 2;
        field = new GameObject[m_fieldSize, m_fieldSize];

        for (int i = 0; i < m_fieldSize; i++)
            for (int j = 0; j < m_fieldSize; j++) 
            {
                GameObject tile = tiles[0];
                Vector3 tilePosition = Vector3.zero;
                Quaternion tileRotation = Quaternion.identity;

                if (i == 0 && j == 0)
                {
                    tile = tiles[tiles.Length - 1];
                    tilePosition = Vector3.zero;
                    tileRotation = Quaternion.identity;
                }
                else if (i == 0 && j == m_fieldSize - 1)
                {
                    tile = tiles[tiles.Length - 1];
                    tilePosition = Vector3.right * m_tileSize * j;
                    tileRotation = Quaternion.Euler(Vector3.up * 90);
                }
                else if (i == m_fieldSize - 1 && j == 0)
                {
                    tile = tiles[tiles.Length - 1];
                    tilePosition = Vector3.back * m_tileSize * i;
                    tileRotation = Quaternion.Euler(Vector3.up * 270);

                }
                else if (i == m_fieldSize - 1 && j == m_fieldSize - 1)
                {
                    tile = tiles[tiles.Length - 1];
                    tilePosition = (Vector3.back * i + Vector3.right * j) * m_tileSize;
                    tileRotation = Quaternion.Euler(Vector3.up * 180);
                }
                else if (i == 0)
                {
                    tile = tiles[tiles.Length - 2];
                    tilePosition = Vector3.right * m_tileSize * j;
                    tileRotation = Quaternion.Euler(Vector3.up * 90);
                }
                else if (i == m_fieldSize - 1)
                {
                    tile = tiles[tiles.Length - 2];
                    tilePosition = (Vector3.back * i + Vector3.right * j) * m_tileSize;
                    tileRotation = Quaternion.Euler(Vector3.up * 270);
                }
                else if (j == 0)
                {
                    tile = tiles[tiles.Length - 2];
                    tilePosition = Vector3.back * m_tileSize * i;
                    tileRotation = Quaternion.identity;
                }
                else if (j == m_fieldSize - 1)
                {
                    tile = tiles[tiles.Length - 2];
                    tilePosition = (Vector3.back * i + Vector3.right * j) * m_tileSize;
                    tileRotation = Quaternion.Euler(Vector3.up * 180);
                }
                else 
                {
                    tile = tiles[Random.Range(0, tiles.Length - 2)];
                    tilePosition = (Vector3.back * i + Vector3.right * j) * m_tileSize;
                    tileRotation = Quaternion.Euler(Vector3.up * Random.Range(0, 4) * 90);
                }

                field[i, j] = Instantiate(tile, tilePosition, tileRotation, origin.transform);
            }
    }
}
