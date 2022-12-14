using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public Piece[,] Pieces => _pieces;
    public IReadOnlyList<PieceButton> PieceButtons => _pieceButtons;
    public int Width => _width;
    public int Height => _height;

    private Piece[,] _pieces;

    [SerializeField]
    private int _width;

    [SerializeField]
    private int _height;

    [SerializeField]
    private Button _buttonPrefab;

    private List<PieceButton> _pieceButtons = new List<PieceButton>();

    private void Awake()
    {
        Create();
        for(int i = 0; i < _height; i++)
        {
            for(int j = 0; j < _width; j++)
            {
                var b = _pieceButtons[(i * _width) + j];
                b.Init(_pieces[i, j]);
            }
        }
    }

    private void Create()
    {
        _pieces = new Piece[_height, _width];
        for (int i = 0; i < _height; i++)
        {
            for(int j = 0; j < _width; j++)
            {
                _pieces[i, j] = new Piece(i, j);
                var button = Instantiate(_buttonPrefab);
                button.transform.parent = gameObject.transform;
                var pieceButton = button.GetComponent<PieceButton>();
                pieceButton.Init(_pieces[i, j]);
                _pieceButtons.Add(pieceButton);
            }
        }
    }

    private void Delete()
    {
        foreach(var b in _pieceButtons)
        {
            DestroyImmediate(b.gameObject);
        }
    }
}
