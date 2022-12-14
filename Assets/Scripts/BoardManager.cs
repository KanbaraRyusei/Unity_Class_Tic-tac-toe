using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BoardManager : SingletonMonoBehaviour<BoardManager>
{
    public Board BoardInstance => _board;

    [SerializeField]
    private Board _board;

    protected override void Awake()
    {
        base.Awake();
    }

    public bool CompleteCheck(bool isPlayer)
    {
        bool isOnlySamePiece = true;
        Piece[] index = new Piece[_board.Height];

        for (int i = 0; i < _board.Height; i++)// 横
        {
            for (int j = 0; j < _board.Width; j++)
            {
                if (!_board.Pieces[i, j].OnPutPiece || _board.Pieces[i, j].IsCircle != isPlayer)
                {
                    isOnlySamePiece = false;
                    break;
                }
            }

            if(isOnlySamePiece)
            {
                return true;
            }
        }

        isOnlySamePiece = true;
        for (int i = 0; i < _board.Width; i++)// 縦
        {
            for (int j = 0; j < _board.Height; j++)
            {
                if (!_board.Pieces[i, j].OnPutPiece || _board.Pieces[i, j].IsCircle != isPlayer)
                {
                    isOnlySamePiece = false;
                    break;
                }
            }

            if(isOnlySamePiece)
            {
                return true;
            }
        }

        for (int i = 0; i < _board.Height; i++)// 左上から右下に向かう斜めの配列
        {
            index[i] = _board.Pieces[i, i];
        }

        DiagonalCheck(index, isPlayer);

        for (int i = _board.Height - 1; i >= 0; i--)// 右上から左下に向かう斜めの配列
        {
            index[i] = _board.Pieces[i, i];
        }

        DiagonalCheck(index, isPlayer);

        return false;
    }

    private bool DiagonalCheck(Piece[] index, bool isPlayer)
    {
        bool isOnlySamePiece = true;
        if (index.Where(x => x.OnPutPiece).Count() == _board.Height)
        {
            for (int i = 0; i < index.Length; i++)
            {
                if (index[i].IsCircle != isPlayer)
                {
                    isOnlySamePiece = false;
                    break;
                }
            }

            if (isOnlySamePiece)
            {
                return true;
            }
        }

        return false;
    }
}
