using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : SingletonMonoBehaviour<TurnManager>
{
    public bool IsPlayerTurn => _isPlayerTurn;

    private bool _isPlayerTurn = true;

    [SerializeField]
    private Enemy _enemy;

    protected override void Awake()
    {
        base.Awake();
    }

    public void NextTurn()
    {
        Debug.Log("NextTurn");
        if(BoardManager.Instance.CompleteCheck(_isPlayerTurn))
        {
            Debug.Log("Win");
            return;
        }

        _isPlayerTurn = !_isPlayerTurn;

        if(!_isPlayerTurn)
        {
            _enemy.PlayTurn();
        }
    }
}
