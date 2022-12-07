using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceButton : MonoBehaviour
{
    public bool IsClick => _isClick;
    public bool IsCircle => _isCircle;

    private Piece _piece;
    private Board _board;
    private Button _button;
    private bool _isClick = false;
    private bool _isCircle = false;

    public void Init(Piece piece, Board board)
    {
        _piece = piece;
        _board = board;
        _button = gameObject.GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        _isClick = true;
        _isCircle = true;
        _button.GetComponent<Image>().color = Color.blue;
        TurnManager.NextTurn();
    }
}
