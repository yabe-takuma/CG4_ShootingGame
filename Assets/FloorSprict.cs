using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSprict : MonoBehaviour
{
    ReflectionProbe probe;
    // Start is called before the first frame update
    void Start()
    {
        this.probe = GetComponent<ReflectionProbe>();
        Screen.SetResolution(1920, 1080, false);
    }

    // Update is called once per frame
    void Update()
    {
        //yに1を掛けて逆側に配置
        this.probe.transform.position =
        new Vector3(Camera.main.transform.position.x,
                    Camera.main.transform.position.y * -1,
                    Camera.main.transform.position.z);
        probe.RenderProbe();
    }
}
