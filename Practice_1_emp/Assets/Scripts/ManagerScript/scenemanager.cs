using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
    public GameObject startButton,exitButton,optionButton,backButton;
    bool optIsActive = false;

    public void onClickStart() {
        StartCoroutine(WaitForStartUIAni());
    }
    public void onClickExit()    {
        StartCoroutine (WaitForExitUIAni());
    }

    public void onClickBack() {
        SceneManager.LoadScene("MainMenu");
    }

    public void onClickOption() {
        Debug.Log("Option about to be Clicked");
        StartCoroutine(WaitForOptUIAni());
    }

    private IEnumerator WaitForOptUIAni() { 
        yield return new WaitForSeconds(0.3f);
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
    private IEnumerator WaitForStartUIAni()
    {
        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene("Game1");
    }
    private IEnumerator WaitForExitUIAni()
    {
        yield return new WaitForSeconds(0.3f);
        Debug.Log("Application.Quit()");
        Application.Quit();
    }
}