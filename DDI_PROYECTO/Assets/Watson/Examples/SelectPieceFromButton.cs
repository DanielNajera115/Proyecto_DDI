using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPieceFromButton : MonoBehaviour
{
    public string selectedButton;
    public Button[] buttons;

    public void SelectThisButton(Button button){
        Text textButton = button.GetComponentInChildren<Text>();
        selectedButton = textButton.text;
        button.GetComponent<Image>().color = Color.red;
        foreach(Button pressedBtn in  buttons){
            if(pressedBtn != button)
                pressedBtn.GetComponent<Image>().color = Color.white;
        }
        selectedButton = selectedButton.ToLower();
    }
}
