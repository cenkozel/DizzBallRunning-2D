using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinEffect : MonoBehaviour
{
    public GameObject KazanmaEfekti;
    public static WinEffect Instance;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void kazanmaefek()
    {
        GameObject patlama = Instantiate(KazanmaEfekti, transform.position, Quaternion.identity);
       
        float sure = patlama.GetComponent<ParticleSystem>().main.duration;
    }


}
