using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board
{
    private Spot[,] spot;
    private char asciiChar = (char) 219;
    public Player player;
    private bool pieceAlreadySelected;

    public Camera mainCamera,blackSideCamera;
    public Board(){
        spot = new Spot[8,8];
        player = new Player();
        this.ResetBoard();
        pieceAlreadySelected = false;
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        blackSideCamera = GameObject.Find("BlackSideCamera").GetComponent<Camera>();
    }

    public bool SelectPiece(int i, int j, string s){
        if(spot[i,j].GetPiece() != null)
            if((spot[i,j].GetPiece().GetName().Equals(s)) && (spot[i,j].GetPiece().isWhite() == player.IsWhiteTurn()) && !pieceAlreadySelected){
                spot[i,j].SetIsSelected(true);
                pieceAlreadySelected = true;
                Debug.Log("Recognize");
                return pieceAlreadySelected;
            }else{
                Debug.Log("No such piece or color");
            }
        return false;
    }

    public void KillPiece(Spot start, Spot end){
        if(end.GetPiece() != null)
            if(start.GetPiece().isWhite() != end.GetPiece().isWhite()){
                end.GetPiece().setKilled(true);
                end.SetPiece(null);
            }
    }

    public void ChangeCamera(){
        
            mainCamera.gameObject.SetActive(true);
        
    }

    public bool MakeMove(int i, int j, string pieceStr, int iEnd, int jEnd){ 
        string spotObj;
        if(spot[i,j].GetPiece() != null)
            if(spot[i,j].GetPiece().canMove(this,spot[i,j],spot[iEnd,jEnd]) && (spot[i,j].GetPiece().isWhite() == player.whiteTurn)){
                KillPiece(spot[i,j],spot[iEnd,jEnd]);
                spot[iEnd,jEnd] = spot[i,j];
                spot[iEnd,jEnd].SetX(iEnd); 
                spot[iEnd,jEnd].SetY(jEnd); 
                spot[i,j] = new Spot(i,j,null);

                spotObj = iEnd.ToString() + "x" + jEnd.ToString();
                spot[iEnd,jEnd].GetPiece().SetMarbleInSpot(GameObject.Find(spotObj).transform.position);
                pieceAlreadySelected = false;
                player.ChangeTurn();
                mainCamera.gameObject.SetActive(player.whiteTurn);
                blackSideCamera.gameObject.SetActive(!player.whiteTurn);
                return true;
            }else{
                Debug.Log("Can not move there");
            }
            return false;
    }

    public string PrintBoard(){
        string boardStr="";
        for(int i=0 ; i<8 ; i++){
            for(int j=0 ; j<8 ; j++){
                if(spot[i,j].GetPiece() is King ){
                    if(spot[i,j].GetIsSelected())
                        boardStr += "K";
                    else
                        boardStr += "k";
                }else if(spot[i,j].GetPiece() is Pawn ){
                    if(spot[i,j].GetIsSelected())
                        boardStr += "P"; 
                    else
                        boardStr += "p"; 
                }else if(spot[i,j].GetPiece() is Queen ){
                    if(spot[i,j].GetIsSelected())
                        boardStr += "Q";
                    else
                        boardStr += "q";
                }else if(spot[i,j].GetPiece() is Knight){
                    if(spot[i,j].GetIsSelected())
                        boardStr += "C";
                    else
                        boardStr += "c";
                }else{
                    boardStr += "o";
                }
            }
            boardStr += "\n";
        }
        return boardStr;
    }
    private void ResetBoard(){
        spot[0,0] = new Spot(0,0,new Rook(true,"torre","Rook_White1"));
        spot[0,1] = new Spot(0,1,new Knight(true,"caballo","Horse_White1"));
        spot[0,2] = new Spot(0,2,new Bishop(true,"alfil","Bishop_White1"));
        spot[0,3] = new Spot(0,3,new King(true,"rey","Rey_White"));
        spot[0,4] = new Spot(0,4,new Queen(true,"reina","Queen_White"));

        spot[0,5] = new Spot(0,5,new Bishop(true,"alfil","Bishop_White1"));
        spot[0,6] = new Spot(0,6,new Knight(true, "caballo","Horse_White2"));
        spot[0,7] = new Spot(0,7,new Rook(true, "torre","Rook_White2"));
        //pawn
        spot[1,0] = new Spot(1,0,new Pawn(true, "peón","Pawn_White1"));
        spot[1,1] = new Spot(1,1,new Pawn(true, "peón","Pawn_White2"));
        spot[1,2] = new Spot(1,2,new Pawn(true, "peón","Pawn_White3"));
        spot[1,3] = new Spot(1,3,new Pawn(true, "peón","Pawn_White4"));
        spot[1,4] = new Spot(1,4,new Pawn(true, "peón","Pawn_White5"));
        spot[1,5] = new Spot(1,5,new Pawn(true, "peón","Pawn_White6"));
        spot[1,6] = new Spot(1,6,new Pawn(true, "peón","Pawn_White7"));
        spot[1,7] = new Spot(1,7,new Pawn(true, "peón","Pawn_White8"));

        //black
        spot[7,0] = new Spot(7,0,new Rook(false,"torre","Rook_Black1"));
        spot[7,1] = new Spot(7,1,new Knight(false,"caballo","Horse_Black1"));
        spot[7,2] = new Spot(7,2,new Bishop(false,"alfil","Bishop_Black1"));
        spot[7,3] = new Spot(7,3,new King(false,"rey","King_Black"));
        spot[7,4] = new Spot(7,4,new Queen(false,"reina","Queen_Black"));
        spot[7,5] = new Spot(7,5,new Bishop(false,"alfil","Bishop_Black2"));
        spot[7,6] = new Spot(7,6,new Knight(false, "caballo","Horse_Black2"));
        spot[7,7] = new Spot(7,7,new Rook(false,"torre","Rook_Black2"));
        //pawn
        spot[6,0] = new Spot(6,0,new Pawn(false, "peón","Pawn_Black1"));
        spot[6,1] = new Spot(6,1,new Pawn(false, "peón","Pawn_Black2"));
        spot[6,2] = new Spot(6,2,new Pawn(false, "peón","Pawn_Black3"));
        spot[6,3] = new Spot(6,3,new Pawn(false, "peón","Pawn_Black4"));
        spot[6,4] = new Spot(6,4,new Pawn(false, "peón","Pawn_Black5"));
        spot[6,5] = new Spot(6,5,new Pawn(false, "peón","Pawn_Black6"));
        spot[6,6] = new Spot(6,6,new Pawn(false, "peón","Pawn_Black7"));
        spot[6,7] = new Spot(6,7,new Pawn(false, "peón","Pawn_Black8"));

        for(int i=2; i<6; i++){
            for(int j=0; j<8;j++){
                spot[i,j] = new Spot(i,j,null);
            }
        }
    }
}
