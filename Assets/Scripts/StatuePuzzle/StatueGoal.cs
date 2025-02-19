using System;
using UnityEngine;

public class StatueGoal : PuzzlePiece
{
    [SerializeField] private GameObject _statue;


    private void OnTriggerEnter(Collider other) {
        if (_statue == other.gameObject) {
            IsSolved = true; 
            CheckSolution?.Invoke();
        }
    }
    private void OnTriggerExit(Collider other) {
        if (_statue == other.gameObject) {
            IsSolved = false;
            CheckSolution?.Invoke();
        }
    }
}
