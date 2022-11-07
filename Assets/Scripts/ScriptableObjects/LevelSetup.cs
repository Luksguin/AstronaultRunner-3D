using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelSetup : ScriptableObject
{
    public int amountStartPieces;
    public int amountPieces;
    public int amountEndPieces;

    public float timeBetweenPieces;

    public List<PieceManager> startPieces;
    public List<PieceManager> pieces;
    public List<PieceManager> endPieces;
}
