using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI score_Text;
    public float score;

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

}

