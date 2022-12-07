using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece
{
    public int Width => _width;
    public int Height => _height;
    public bool OnPutPiece => _onPutPiece;
    public bool IsCircle => _isCircle;

    private int _width;
    private int _height;
    private bool _onPutPiece = false;
    private bool _isCircle = false;

    public Piece(int width, int height)
    {
        _width = width;
        _height = height;
    }

    public void PutPiece(bool flag)
    {
        _onPutPiece = true;
        _isCircle = flag;
    }
}
