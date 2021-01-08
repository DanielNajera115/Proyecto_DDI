using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{
    
    public Queen(bool white, string name,string marblePiece) : base(white, name, marblePiece)
    { 
        
    } 
    
    public override bool canMove(Board board, Spot start, Spot end)
    {
        int XAxis,YAxis;

        XAxis = Mathf.Abs(start.GetX() - end.GetX());
        YAxis = Mathf.Abs(start.GetY() - end.GetY());

        if(end.GetPiece() != null){
            if(((XAxis == 0 && YAxis != 0) || (XAxis != 0 && YAxis == 0) || (XAxis == YAxis)) && (this.isWhite() != end.GetPiece().isWhite())){
                return true;
            }
        }else{
            if(((XAxis == 0 && YAxis != 0) || (XAxis != 0 && YAxis == 0) || (XAxis == YAxis))){
                return true;
            }
        }

        return false;
    }
}
