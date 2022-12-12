using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI score_Text;

    public GameObject pauseBG, menuButton,speedSlider;
    public float score;
    private bool isOnPause;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score_Text.text = "Score: " + score;

            if (score > 1) {
                Debug.Log("GameOver");
                SceneManager.LoadScene("GameOver");
            }
    }

    public void OnClickPause() {
        if (isOnPause == false) {
            Time.timeScale = 0.0f;
            pauseBG.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
            speedSlider.gameObject.SetActive(true);
            isOnPause = true;
        }
        else {
            Time.timeScale = 1.0f;
            pauseBG.gameObject.SetActive(false);
            menuButton.gameObject.SetActive(false);
            speedSlider.gameObject.SetActive(false);
            isOnPause = false;
        }
    }

    public void OnClickMenuButton() {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

}

