using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TurnManager
{
    public static bool IsPlayerTurn => _isPlayerTurn;

    private static bool _isPlayerTurn = true;

    public static void NextTurn()
    {

        _isPlayerTurn = !_isPlayerTurn;
    }
}
