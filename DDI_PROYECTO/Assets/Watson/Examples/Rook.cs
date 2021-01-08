using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    
    public Rook(bool white, string name, string marblePiece) : base(white, name, marblePiece)
    { 
         
    } 
   
    public override bool canMove(Board board, Spot start, Spot end)
    {
        int XAxis,YAxis;

        XAxis = Mathf.Abs(start.GetX() - end.GetX());
        YAxis = Mathf.Abs(start.GetY() - end.GetY());

        if(end.GetPiece() != null){
            if((XAxis == 0 && YAxis != 0) || (XAxis != 0 && YAxis == 0) && (this.isWhite() != end.GetPiece().isWhite())){
                return true;
            }
        }else{
            if((XAxis == 0 && YAxis != 0) || (XAxis != 0 && YAxis == 0))
                return true;
        }
        
        return false;
    }
}