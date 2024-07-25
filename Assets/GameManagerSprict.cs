using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerSprict : MonoBehaviour
{
    public GameObject enemy;
    public GameObject gameOverText;
    public AudioSource hitAudioSource;
    public TextMeshProUGUI scoreText;
    public GameObject bombParticle;

    private bool gameOverFlag = false;
    private int score = 0;

    int gameTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //ゲームオーバー開始
    public void GameOverStart()
    {
        gameOverText.SetActive(true);
        gameOverFlag = true;
    }

    public bool IsGameOver()
    {
        return gameOverFlag;
    }

    public void Hit(Vector3 position)
    {
        hitAudioSource.Play();
        score += 1;
        Instantiate(bombParticle, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //スコア表示
        scoreText.text = "SCORE" + score;

        if (gameOverFlag == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
    }

    private void FixedUpdate()
    {
        gameTimer++;
        int max = 50 - gameTimer / 100;
        int r = Random.Range(0, max);
        if(gameOverFlag==true)
        {
            return;
        }
        if(r==0)
        {
            float x = Random.Range(-3.0f, 3.0f);
            Instantiate(enemy, new Vector3(x, 0, 10), Quaternion.identity);
        }
       
        
    }
}
