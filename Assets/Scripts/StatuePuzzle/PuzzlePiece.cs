using System;
using UnityEngine;

public abstract class PuzzlePiece : MonoBehaviour
{
    public bool IsSolved;
    public Action CheckSolution { get; set; } = delegate { };

}
