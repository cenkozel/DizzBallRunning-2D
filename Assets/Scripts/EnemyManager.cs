using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour

    
{
    bool dead = false;
    public float health;
    public float damage;
    bool coliderBusy = false;
    public Slider slider;
    public Transform floatingtext;
    public GameObject PatlamaEffect;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
        

    }

    // Update is called once per frame
    void Update()
    {

        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !coliderBusy)
        {
            coliderBusy = true;
            other.GetComponent<PlayerManager>().GetDamage(damage);
        }
        else if(other.tag=="Bullet")
        {
            GetDamage(other.GetComponent<BulletManager>().bulletDamage);
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            coliderBusy = false;
        }
    }
    public void GetDamage(float damage)
    {
        Instantiate(floatingtext, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();
        if ((health - damage) >= 0)
        {
            health -= damage;

        }
        else
        {
            health = 0;
        }
        slider.value = health;
        AmIDead();
    }
    void AmIDead()
    {
        if (health <= 0)
        {
            
            DataManager.Instance.EnemyKilled++;
            GameObject patlama = Instantiate(PatlamaEffect, transform.position, Quaternion.identity);
            dead = true;
            float sure = patlama.GetComponent<ParticleSystem>().main.duration;
            Destroy(gameObject);
        }
    }
   

}
