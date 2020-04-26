using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturePiece : MonoBehaviour
{
    public void CaptureSpecifiedPiece(GameObject piece)
    {
        piece.SetActive(false);
    }
}
