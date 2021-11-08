using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFall : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float falldelay;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y<-60f)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(falldelay);
        rb2d.isKinematic = false;
        yield return 0;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }
   
}
