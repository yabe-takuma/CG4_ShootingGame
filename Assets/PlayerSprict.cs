using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprict : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;
    public GameObject bullet;
    public GameObject gameManager;
    private GameManagerSprict gameManagerScript;

    int bulletTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Scriptを取得する
        gameManagerScript = gameManager.GetComponent<GameManagerSprict>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 2.0f;
        float stageMax = 4.0f;
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("mode", true);
            animator.SetBool("leftmode", false);
            if (transform.position.x<stageMax)
            {
                rb.velocity = new Vector3(moveSpeed, 0, 0);
              
            }
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("leftmode", true);
            animator.SetBool("mode", false) ;
            if (transform.position.x>-stageMax)
            {
                rb.velocity = new Vector3(-moveSpeed, 0, 0);
               
            }
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
            animator.SetBool("mode", false);
            animator.SetBool("leftmode", false);
        }
        if(gameManagerScript.IsGameOver()==true)
        {
            rb.velocity = new Vector3(0, 0, 0);
            return;
        }
    }

    void FixedUpdate()
    {

        if (gameManagerScript.IsGameOver() == true)
        {
            return;
        }
        //弾発射
        if (bulletTimer == 0)
        {
            Vector3 position = transform.position;

            position.y += 0.8f;
            position.z += 1.0f;

            Instantiate(bullet, position, Quaternion.identity);
            bulletTimer = 1;
        }
        else
        {
            bulletTimer++;
            if (bulletTimer > 25)
            {
                bulletTimer = 0;
            }
        }
      
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            gameManagerScript.GameOverStart();
        }
    }
}
