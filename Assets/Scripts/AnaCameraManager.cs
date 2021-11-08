using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnaCameraManager : MonoBehaviour
{
    private Transform Player;
    [SerializeField]
    private float smoothx;
    [SerializeField]
    private float smoothy;
    [SerializeField]
    private float minX, minY, maxX, maxY;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (DataManager.Instance.yasiyormu)
        {
            float posX = Mathf.MoveTowards(transform.position.x, Player.position.x, smoothx);
            float posY = Mathf.MoveTowards(transform.position.y, Player.position.y, smoothy);
            transform.position = new Vector3(Mathf.Clamp(posX, minX, maxX), Mathf.Clamp(posY, minY, maxY), transform.position.z);
        }
    }
}
