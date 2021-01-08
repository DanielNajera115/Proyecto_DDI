using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece
{
    public bool killed = false; 
    public bool white = false; 
    public string name;
    public GameObject marblePiece;
    public Piece(bool white, string name, string marblePiece) 
    { 
        this.setWhite(white); 
        this.SetName(name);
        this.SetPiece(marblePiece);
    } 
  
    public bool isWhite() 
    { 
        return this.white; 
    } 
    public void SetName(string s){
        this.name = s;
    }
    public string GetName(){
        return this.name;
    }

    public void SetMarbleInSpot(Vector3 pos){
        float xPos = pos[0], yPos = pos[2];
        float yAxis = marblePiece.transform.localPosition[1];
        marblePiece.transform.localPosition = new Vector3(xPos,yAxis,yPos);
    }

    public void SetMarbleDisappeard(){
        marblePiece.gameObject.SetActive(false);
    }

    public void SetPiece(string s){
        this.marblePiece = GameObject.Find(s);
    }

    public GameObject SetPiece(){
        return this.marblePiece;
    }
  
    public void setWhite(bool white) 
    { 
        this.white = white; 
    } 
  
    public bool isKilled() 
    { 
        return this.killed; 
    } 
  
    public void setKilled(bool killed) 
    { 
        this.killed = killed; 
    } 
  
    public abstract bool canMove(Board board,  
                                 Spot start, Spot end); 
}
