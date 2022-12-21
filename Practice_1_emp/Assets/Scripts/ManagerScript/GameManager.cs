using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI score_Text;

    public GameObject pauseBG, menuButton,basicButtons;
    private bool isOnPause;
    public bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver == true) {
            Time.timeScale = 0;
            pauseBG.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
            basicButtons.gameObject.SetActive(false);
        }
    }

    public void OnClickPause() {
        if (isOnPause == false) {
            Time.timeScale = 0.0f;
            pauseBG.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
            basicButtons.gameObject.SetActive(false);
            isOnPause = true;
            Debug.Log("Paused");
        }
        else if(isOnPause == true) {
            Time.timeScale = 1.0f;
            pauseBG.gameObject.SetActive(false);
            menuButton.gameObject.SetActive(false);
            basicButtons.gameObject.SetActive(true);
            isOnPause = false;
            Debug.Log("Play");
        }
    }

    public void OnClickMenuButton() {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

}

