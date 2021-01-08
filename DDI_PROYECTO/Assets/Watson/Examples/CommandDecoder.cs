using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CommandDecoder : MonoBehaviour
{
    public GameEngine gameEngine;
    public InputField input;
    public SelectPieceFromButton selectPieceFromButton;

    string str;
    int x,y,i,j;
    bool isAlreadySelected = false, isAlreadyMoved = true;

    public void DecodeString(string str){
        char letra;
        
        string[] splitCommand = str.Split(' ');
        Debug.Log("Length: "+ splitCommand.Length);
        str = selectPieceFromButton.selectedButton;
        if(!isAlreadySelected && CheckStringFromStreaming(splitCommand) && isAlreadyMoved){
            letra = splitCommand[0][0];
            x = Int32.Parse(splitCommand[1]);
            x--;
            y = letra - 97;
            isAlreadySelected = gameEngine.board.SelectPiece(x, y, str);
            isAlreadyMoved = false;
        }else if(isAlreadySelected && CheckStringFromStreaming(splitCommand) && !isAlreadyMoved){
            letra = splitCommand[0][0];
            i = Int32.Parse(splitCommand[1]);
            i--;
            j = letra - 97;
            isAlreadyMoved = gameEngine.board.MakeMove(x,y,str,i,j);
            if(isAlreadyMoved)
                isAlreadySelected = false;
        }else{
            Debug.Log("Wrong Command");
        }
    }

    public bool CheckStringFromStreaming(string[] commandStr){

        if(commandStr[1].Equals("uno")){
            commandStr[1] = "1";
        }

        if((commandStr[0].Length > 1) || (commandStr[1].Length > 1) || (commandStr.Length != 3)){
            return false;
        }

        return true;
    }

    public void PressedButtonFunction(){
        DecodeString(input.text);
    }
}
