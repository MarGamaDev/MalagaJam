using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpinPuzzle : MonoBehaviour
{
    [SerializeField] private List<PuzzleSquare> _squareList = new List<PuzzleSquare>();
    public UnityEvent PuzzleFinishedEvent;

    private void Update()
    {
        CheckCompletion();
    }

    private void CheckCompletion()
    {
        bool puzzleCompletion = true;
        foreach (PuzzleSquare square in _squareList)
        {
            if (square.CurrentOrientation != PuzzleSquare.Orientation.Up || square._targetOrientation != PuzzleSquare.Orientation.Up)
            {
                puzzleCompletion = false;
                break;
            }
        }

        if (puzzleCompletion)
        {
            PuzzleFinishedEvent?.Invoke();
            Debug.Log("puzzle done!");
        }
    }
}
