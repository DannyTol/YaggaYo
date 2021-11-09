using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public int score;
    public Text scoreText;
    
    private void Awake()
    {
        score += FindObjectOfType<PlayerMovement>().points;
        scoreText.text = (score.ToString());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
    }
}
