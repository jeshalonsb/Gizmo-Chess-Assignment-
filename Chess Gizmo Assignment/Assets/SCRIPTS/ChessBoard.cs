using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public int gridSize = 8;
    public float tileSize = 1.0f;
    public Color light = Color.white;
    public Color dark = Color.black;
    private void OnDrawGizmos()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                if ((x + z)%2 == 0)
                {
                    Gizmos.color = light;
                }
                else
                {
                     Gizmos.color = dark;
                }

                Vector3 position = new Vector3((x - gridSize / 2) * tileSize + tileSize / 2f, 0, (z - gridSize / 2) * tileSize + tileSize / 2);

                Gizmos.DrawCube(position, new Vector3(tileSize, 0, tileSize));
            }
        }
    }
}