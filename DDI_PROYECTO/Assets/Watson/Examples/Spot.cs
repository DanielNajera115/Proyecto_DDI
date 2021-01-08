using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot
{
    public Piece piece;
    public int x;
    public int y;
    public bool isSelected;

    public Spot(int x, int y, Piece p)
    {
        this.piece = p;
        this.x = x;
        this.y = y;
        this.isSelected = false;
    }
    public void SetX(int x){
        this.x = x;
    }
    public void SetY(int y){
        this.y = y;
    }
    public void SetPiece(Piece p ){
        this.piece = p;
    }
    public void SetIsSelected(bool s){
        this.isSelected = s;
    }
    public bool GetIsSelected(){
        return this.isSelected;
    }
    public int GetX(){
        return this.x;
    }
    public int GetY(){
        return this.y;
    }
    public Piece GetPiece(){
        return this.piece;
    }
}
