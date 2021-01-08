using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
   
    public Bishop(bool white, string name, string marblePiece) : base(white, name, marblePiece)
    { 
       
    } 
   
    public override bool canMove(Board board, Spot start, Spot end)
    {
        int XAxis,YAxis;

        XAxis = Mathf.Abs(start.GetX() - end.GetX());
        YAxis = Mathf.Abs(start.GetY() - end.GetY());

        if(end.GetPiece() != null){
            if((XAxis == YAxis) && (this.isWhite() != end.GetPiece().isWhite()))
                return true;
        }else{
            if(XAxis == YAxis)
                return true;
        }
        
        return false;
    }
}
