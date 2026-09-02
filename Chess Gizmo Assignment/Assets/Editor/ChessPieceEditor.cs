using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ChessPiece))]
public class ChessPieceEditor : Editor
{
    private void OnSceneGUI()
    {
        ChessPiece chessPiece = (ChessPiece)target;

        Transform pieceTransform = chessPiece.transform;

        Vector3 position = pieceTransform.position;

        float size = chessPiece.tileSize;

        Handles.color = Color.yellow;

        Vector3 p1 = position + new Vector3(-size / 2, 0.1f, -size / 2);
        Vector3 p2 = position + new Vector3(-size / 2, 0.1f, size / 2);
        Vector3 p3 = position + new Vector3(size / 2, 0.1f, size / 2);
        Vector3 p4 = position + new Vector3(size / 2, 0.1f, -size / 2);

        Handles.DrawLine(p1, p2);
        Handles.DrawLine(p2, p3);
        Handles.DrawLine(p3, p4);
        Handles.DrawLine(p4, p1);

        EditorGUI.BeginChangeCheck();

        Vector3 newPosition = Handles.PositionHandle(
            position,
            pieceTransform.rotation
        );

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(pieceTransform, "Move Chess Piece");

            pieceTransform.position = newPosition;
        }
    }
}
