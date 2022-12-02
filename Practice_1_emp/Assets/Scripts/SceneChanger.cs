using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void onClickStart() {
        SceneManager.LoadScene("Game1");
    }
    public void onClickExit()
    {
        Debug.Log("Application.Quit()");
        Application.Quit();
    }
    public void onClickMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
