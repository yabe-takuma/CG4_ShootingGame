using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSprict : MonoBehaviour
{
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy, new Vector3(0, 0, 10), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}