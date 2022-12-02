using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainPlayer_Movement : MonoBehaviour
{
    public TextMeshPro livesRemaining;
    private Rigidbody2D main_body;
    private float horizontalInput;
    [SerializeField] private float speed;
    private int livesCount = 5;

    // Start is called before the first frame update
    void Start()
    {
        main_body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        livesRemaining.text = "Lives Remanining: " + livesCount;
        horizontalInput = Input.GetAxis("Horizontal");
        main_body.velocity = new Vector2(horizontalInput * (speed / 2), main_body.velocity.y);

        if (Input.GetKey(KeyCode.Space)) {
            main_body.velocity = new Vector2(main_body.velocity.x, speed);
        }

        if (livesCount < 1) {
            Debug.Log("GameOver");
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy touch");
            livesCount--;
        }
    }
}
