using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtPiece : MonoBehaviour
{
    public GameObject currentPiece;

    public void ChangePiece(GameObject piece)
    {
        if (currentPiece != null) Destroy(currentPiece);

        currentPiece = Instantiate(piece, transform);
        currentPiece.transform.localPosition = Vector3.zero;
    }
}
