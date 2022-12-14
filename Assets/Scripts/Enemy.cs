using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void PlayTurn()
    {
        int num = BoardEvaluationManager.Instance.CountPieceLine(false)
            - BoardEvaluationManager.Instance.CountPieceLine(true);

        BoardManager.Instance.BoardInstance.PieceButtons[0].OnClick(false);

        TurnManager.Instance.NextTurn();
    }
}
