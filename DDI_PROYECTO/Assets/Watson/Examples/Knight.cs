using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    
    public Knight(bool white, string name,string marblePiece) : base(white, name, marblePiece)
    { 
        
    } 
    
   public override bool canMove(Board board, Spot start, Spot end)
    {
        int XAxis,YAxis;

        XAxis = Mathf.Abs(start.GetX() - end.GetX());
        YAxis = Mathf.Abs(start.GetY() - end.GetY());

        if(((XAxis == 2 && YAxis == 1) || (XAxis == 1 && YAxis == 2)) && (end.GetPiece() != null)){
            if(end.GetPiece().isWhite() != start.GetPiece().isWhite())
                return true;
        }else if(((XAxis == 2 && YAxis == 1) || (XAxis == 1 && YAxis == 2)) && (end.GetPiece() == null)){
            return true;
        }
        
        return false;
    }
}
