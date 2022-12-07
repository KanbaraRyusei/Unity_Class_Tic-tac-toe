using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public Piece[,] Pieces => _pieces;
    public int Width => _width;
    public int Height => _height;

    private Piece[,] _pieces;

    [SerializeField]
    private int _width;

    [SerializeField]
    private int _height;

    [SerializeField]
    private Button _buttonPrefab;

    public void Create()
    {
        _pieces = new Piece[_height, _width];
        for (int i = 0; i < _height; i++)
        {
            for(int j = 0; j < _width; j++)
            {
                _pieces[i, j] = new Piece(i, j);
                var b = Instantiate(_buttonPrefab);
                var p = b.GetComponent<PieceButton>();
                p.Init(_pieces[i, j], this);
            }
        }
    }
}
