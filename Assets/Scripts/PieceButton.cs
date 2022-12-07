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
        _button.onClick.AddListener(OnClick);
        Debug.Log("Init");
    }

    private void OnClick()
    {
        _piece.PutPiece(true);
        _isClick = true;
        _isCircle = true;
        _button.GetComponent<Image>().color = Color.blue;
        TurnManager.NextTurn();
    }
}
