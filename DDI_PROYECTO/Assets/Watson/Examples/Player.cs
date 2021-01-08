using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool whiteTurn = true;
    
    
    public bool IsWhiteTurn(){
        return whiteTurn;
    }

    public void ChangeTurn(){
        this.whiteTurn = !this.whiteTurn;
    }
}
