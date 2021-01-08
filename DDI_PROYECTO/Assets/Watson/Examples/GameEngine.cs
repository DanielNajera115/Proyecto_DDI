using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{
    public Board board;
    public Text txtBrd;
    // Start is called before the first frame update
    void Start()
    {
        board = new Board();
    }
}
