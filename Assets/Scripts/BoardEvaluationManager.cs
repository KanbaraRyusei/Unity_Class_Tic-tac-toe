using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BoardEvaluationManager : SingletonMonoBehaviour<BoardEvaluationManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    public int CountPieceLine(bool isPlayer)
    {
        int count = 0;
        bool isOnlySamePiece = true;
        Piece[] index = new Piece[BoardManager.Instance.BoardInstance.Height];

        for(int i = 0; i < BoardManager.Instance.BoardInstance.Height; i++)// ��
        {
            for(int j = 0; j < BoardManager.Instance.BoardInstance.Width; j++)
            {
                if(BoardManager.Instance.BoardInstance.Pieces[i, j].OnPutPiece)
                {
                    if(BoardManager.Instance.BoardInstance.Pieces[i, j].IsCircle != isPlayer)
                    {
                        isOnlySamePiece = false;
                        break;
                    }
                }
            }

            if(isOnlySamePiece)
            {
                count++;
            }
        }

        isOnlySamePiece = true;
        for (int i = 0; i < BoardManager.Instance.BoardInstance.Width; i++)// �c
        {
            for (int j = 0; j < BoardManager.Instance.BoardInstance.Height; j++)
            {
                if (BoardManager.Instance.BoardInstance.Pieces[i, j].OnPutPiece)
                {
                    if (BoardManager.Instance.BoardInstance.Pieces[i, j].IsCircle != isPlayer)
                    {
                        isOnlySamePiece = false;
                        break;
                    }
                }
            }

            if (isOnlySamePiece)
            {
                count++;
            }
        }

        // �΂�
        for(int i = 0; i < BoardManager.Instance.BoardInstance.Height; i++)
        {
            index[i] = BoardManager.Instance.BoardInstance.Pieces[i, i];// ���ォ��E���Ɍ������΂߂̔z��
        }

        if (index.Where(x => x.OnPutPiece).Count() == index.Where(x => x.OnPutPiece).Where(x => x.IsCircle == isPlayer).Count())
        {
            count++;
        }

        for(int i = BoardManager.Instance.BoardInstance.Height - 1; i >= 0; i--)
        {
            index[i] = BoardManager.Instance.BoardInstance.Pieces[i, i];// �E�ォ�獶���Ɍ������΂߂̔z��
        }

        if(index.Where(x => x.OnPutPiece).Count() == index.Where(x => x.OnPutPiece).Where(x => x.IsCircle == isPlayer).Count())
        {
            count++;
        }

        return count;
    }
}
