using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSprict : MonoBehaviour
{
    public Rigidbody rb;

    float moveSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
            rb.velocity = new Vector3(0, 0, moveSpeed);
            Destroy(gameObject, 5);
        
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
