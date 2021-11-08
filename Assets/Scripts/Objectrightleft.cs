using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectrightleft : MonoBehaviour
{
    public float speed = 2.0f;    //objenin hızı
    public Vector3 startPos1;
    public Vector3 startPos2;

    public Transform currentPoint;
    public GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        startPos1 = platform.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, startPos1, Time.deltaTime * speed);
        if(platform.transform.position==startPos1)
        {
            startPos1 = startPos2;
            if(startPos1==startPos2)
            {
                startPos2 = platform.transform.position;
            }
        }    
    }
}
