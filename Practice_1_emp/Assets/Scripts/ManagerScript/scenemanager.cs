using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
    public GameObject startButton,exitButton,optionButton,backButton;
    bool optIsActive = false;

    public void onClickStart() {
        SceneManager.LoadScene("Game1");
    }
    public void onClickExit()    {
        Debug.Log("Application.Quit()");
        Application.Quit();
    }

    public void onClickBack() {
        SceneManager.LoadScene("MainMenu");
    }

    public void onClickOption() {
        Debug.Log("Option about to be Clicked");
        StartCoroutine(WaitForOptUIAni());
    }

    private IEnumerator WaitForOptUIAni() { 
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Option is Clicked");
        if (optIsActive == false)
        {
            Debug.Log("You Are inside Options. But is not what u Thinkkkk...:)");
            optIsActive = true;
            startButton.gameObject.SetActive(false);
            optionButton.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(false);
            backButton.gameObject.SetActive(true);
        }
    }
}
