using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BoardEvaluationManager : MonoBehaviour
{
    [SerializeField]
    private Board _board;

    public int CountPieceLine(bool isPlayer)
    {
        int count = 0;
        bool isOnlySamePiece = true;
        Piece[] index = new Piece[_board.Height];

        for(int i = 0; i < _board.Height; i++)// ‰¡
        {
            for(int j = 0; j < _board.Width; j++)
            {
                if(_board.Pieces[i, j].OnPutPiece)
                {
                    if(_board.Pieces[i, j].IsCircle != isPlayer)
                    {
                        isOnlySamePiece = false;
                    }
                }
            }

            if(isOnlySamePiece)
            {
                count++;
            }
        }

        isOnlySamePiece = true;
        for (int i = 0; i < _board.Width; i++)// c
        {
            for (int j = 0; j < _board.Height; j++)
            {
                if (_board.Pieces[i, j].OnPutPiece)
                {
                    if (_board.Pieces[i, j].IsCircle != isPlayer)
                    {
                        isOnlySamePiece = false;
                    }
                }
            }

            if (isOnlySamePiece)
            {
                count++;
            }
        }

        for(int i = 0; i < _board.Height; i++)
        {
            index[i] = _board.Pieces[i, i];
        }

        if (index.Where(x => x.OnPutPiece).Count() == index.Where(x => x.OnPutPiece).Where(x => x.IsCircle == isPlayer).Count())
        {
            count++;
        }

        for(int i = _board.Height; i > 0; i--)
        {
            index[i] = _board.Pieces[i, i];
        }

        if(index.Where(x => x.OnPutPiece).Count() == index.Where(x => x.OnPutPiece).Where(x => x.IsCircle == isPlayer).Count())
        {
            count++;
        }

        return count;
    }
}
