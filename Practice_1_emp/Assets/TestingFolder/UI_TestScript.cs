using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TestScript : MonoBehaviour
{
    public void onClickStart() {
        Debug.Log("Start is Clicked");
    }
    public void onClickExit() {
        Debug.Log("Application.Quit()");
    }
    public void onClickMainMenu() {
        Debug.Log("MainMenu is Clicked");
    }

    public void onClickOption() {
        Debug.Log("Option is Clicked");
    }
}
