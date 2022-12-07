using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BoardManager : MonoBehaviour
{
    [SerializeField]
    private Board _board;

    public bool CompleteCheck(bool isPlayer)
    {
        bool isOnlySamePiece = true;
        Piece[] index = new Piece[_board.Height];

        for (int i = 0; i < _board.Height; i++)// ‰¡
        {
            for (int j = 0; j < _board.Width; j++)
            {
                if (!_board.Pieces[i, j].OnPutPiece)
                {
                    break;
                }

                if(_board.Pieces[i, j].IsCircle != isPlayer)
                {
                    isOnlySamePiece = false;
                }
            }

            if(isOnlySamePiece)
            {
                return true;
            }
        }

        isOnlySamePiece = true;
        for (int i = 0; i < _board.Width; i++)// c
        {
            for (int j = 0; j < _board.Height; j++)
            {
                if (!_board.Pieces[i, j].OnPutPiece)
                {
                    break;
                }

                if (_board.Pieces[i, j].IsCircle != isPlayer)
                {
                    isOnlySamePiece = false;
                }
            }

            if(isOnlySamePiece)
            {
                return true;
            }
        }

        isOnlySamePiece = true;
        for (int i = 0; i < _board.Height; i++)
        {
            index[i] = _board.Pieces[i, i];
        }

        DiagonalCheck(index, isPlayer);

        isOnlySamePiece = true;
        for (int i = _board.Height; i > 0; i--)
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
