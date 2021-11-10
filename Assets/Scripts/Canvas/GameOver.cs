using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public int score;
    public Text scoreText;

    [Space]
    public GameObject target1;

    
    
    private void Awake()
    {
        score += FindObjectOfType<PlayerMovement>().points;
        scoreText.text = (score.ToString());

        // Pause everything
        Time.timeScale = 0;

        

        

      
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
            Destroy(gameObject);
            Time.timeScale = 1;
            
        }
    }
    
}
