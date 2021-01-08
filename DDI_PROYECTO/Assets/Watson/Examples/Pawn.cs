using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    
    public Pawn(bool white, string name, string marblePiece) : base(white, name, marblePiece)
    { 
       
    } 
    
    public override bool canMove(Board board, Spot start, Spot end)
    {

        int XAxis,YAxis;

        XAxis = Mathf.Abs(start.GetX() - end.GetX());
        YAxis = Mathf.Abs(start.GetY() - end.GetY());

        if (end.GetPiece() != null) { 
            Debug.Log("Or Here");
            if(end.GetPiece().isWhite() != start.GetPiece().isWhite() && ((XAxis + YAxis) == 2))
                if(start.GetPiece().isWhite() == true)
                return true; 
        }else if((end.GetPiece() == null)){
            Debug.Log(start.GetY());
            Debug.Log(end.GetY());
            if((start.GetPiece().isWhite() == true) && ((start.GetX() + 1) == end.GetX()) && (start.GetY() == end.GetY()))
                return true;
            else if((start.GetPiece().isWhite() == false) && ((start.GetX() - 1) == end.GetX()) && (start.GetY() == end.GetY()))
                return true; 
        }
        return false;   
    }
}
