using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    public King(bool white, string name, string marblePiece) : base(white, name, marblePiece)
    { 
    } 
   
    public override bool canMove(Board board, Spot start, Spot end)
    {
        int XAxis,YAxis;

        XAxis = Mathf.Abs(start.GetX() - end.GetX());
        YAxis = Mathf.Abs(start.GetY() - end.GetY());
        
        if((start.GetX() + 1 == end.GetX()) && (start.GetY() + 1 == end.GetY()) && (end.GetPiece() != null)){
            if (end.GetPiece().isWhite() != this.isWhite())
                return true;
        }else if((XAxis + YAxis == 1) && (end.GetPiece() != null)){
            if (end.GetPiece().isWhite() != this.isWhite())
                return true;
        }
        return false;
    }
}
