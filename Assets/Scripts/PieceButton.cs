using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceButton : MonoBehaviour
{
    public bool IsClick => _isClick;
    public bool IsCircle => _isCircle;

    private Piece _piece;
    private Button _button;
    private bool _isClick = false;
    private bool _isCircle = false;

    public void Init(Piece piece)
    {
        _piece = piece;
        _button = gameObject.GetComponent<Button>();
        ButtonInit();
    }

    public void ButtonInit()
    {
        _button.onClick.AddListener(() => OnClick(TurnManager.Instance.IsPlayerTurn));
    }

    public void OnClick(bool isPlayer)
    {
        if (_isClick) return;
        _piece.PutPiece(isPlayer);
        _isClick = true;
        _isCircle = isPlayer;
        if (isPlayer)
        {
            _button.GetComponent<Image>().color = Color.blue;
        }
        else
        {
            _button.GetComponent<Image>().color = Color.red;
        }
        TurnManager.Instance.NextTurn();
        ButtonInit();
    }
}
