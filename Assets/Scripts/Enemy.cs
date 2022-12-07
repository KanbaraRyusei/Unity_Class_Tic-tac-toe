using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Update()
    {
        if(!TurnManager.IsPlayerTurn)
        {
            PlayTurn();
        }
    }

    private void PlayTurn()
    {

    }
}
