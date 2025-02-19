
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    public bool IsSolved;

    [SerializeField] private UnityEvent _puzzleSolvedAction;
    [SerializeField] private UnityEvent _puzzleUnSolvedAction;

    [SerializeField] private List<PuzzlePiece> _puzzlePieces = new();

    private void Awake() {
        foreach (var goal in _puzzlePieces) {
            if (goal != null) {
                goal.CheckSolution += CheckIfSolved;
            }
        }
    }

    private void CheckIfSolved() {
        IsSolved = true;
        foreach (var goal in _puzzlePieces) {
            if (goal != null && !goal.IsSolved) {
                IsSolved = false;
            }
        }

        if (IsSolved) {
            _puzzleSolvedAction?.Invoke();
        } else {
            _puzzleUnSolvedAction?.Invoke();
        }
    }
}
