using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public enum Pieces
    {
        Pawn,
        Knight,
        Bishop,
        Rook,
        Queen,
        King
    }

    public Pieces piece;
    public Color tint = Color.white;

    public float tileSize = 1f;
    public Color moveColor = Color.green;

    private void OnDrawGizmos()
    {
        string iconName = "";

        switch (piece)
        {
            case Pieces.Pawn:
                iconName = "Pawn.png";
                break;

            case Pieces.Knight:
                iconName = "Knight.png";
                break;

            case Pieces.Bishop:
                iconName = "Bishop.png";
                break;

            case Pieces.Rook:
                iconName = "Rook.png";
                break;

            case Pieces.Queen:
                iconName = "Queen.png";
                break;

            case Pieces.King:
                iconName = "King.png";
                break;
        }

        Gizmos.DrawIcon(
            transform.position,
            iconName,
            true,
            tint
        );
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = moveColor;

        switch (piece)
        {
            case Pieces.Pawn:
                DrawMove(0, 1);
                break;

            case Pieces.Knight:
                DrawMove(1, 2);
                DrawMove(2, 1);
                DrawMove(-1, 2);
                DrawMove(-2, 1);
                DrawMove(1, -2);
                DrawMove(2, -1);
                DrawMove(-1, -2);
                DrawMove(-2, -1);
                break;

            case Pieces.Bishop:
                for (int i = 1; i < 8; i++)
                {
                    DrawMove(i, i);
                    DrawMove(-i, i);
                    DrawMove(i, -i);
                    DrawMove(-i, -i);
                }
                break;

            case Pieces.Rook:
                for (int i = 1; i < 8; i++)
                {
                    DrawMove(i, 0);
                    DrawMove(-i, 0);
                    DrawMove(0, i);
                    DrawMove(0, -i);
                }
                break;

            case Pieces.Queen:
                for (int i = 1; i < 8; i++)
                {
                    DrawMove(i, 0);
                    DrawMove(-i, 0);
                    DrawMove(0, i);
                    DrawMove(0, -i);

                    DrawMove(i, i);
                    DrawMove(-i, i);
                    DrawMove(i, -i);
                    DrawMove(-i, -i);
                }
                break;

            case Pieces.King:
                for (int x = -1; x <= 1; x++)
                {
                    for (int z = -1; z <= 1; z++)
                    {
                        if (x == 0 && z == 0)
                            continue;

                        DrawMove(x, z);
                    }
                }
                break;
        }
    }

    private void DrawMove(int x, int z)
    {
        Vector3 position =
            transform.position +
            new Vector3(x * tileSize, 0.05f, z * tileSize);

        Gizmos.DrawCube(
            position,
            new Vector3(
                tileSize * 0.9f,
                0.02f,
                tileSize * 0.9f
            )
        );
    }
}