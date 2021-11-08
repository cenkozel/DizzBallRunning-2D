using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeEnemy : MonoBehaviour
{
    bool dead = false;
    public float health, firebulletSpeed;
    public float damage;
    bool coliderBusy = false;
    public Slider slider;
    public Transform firebullet, floatingtext;
    public GameObject PatlamaEffect;
    Transform muzzlee;

    public float speed = 2.0f;    //objenin hızı
    public Vector3 startPos1;
    public Vector3 startPos2;

    public Transform currentPoint;
    public GameObject platform;
    public float zaman;
   

    // Start is called before the first frame update
    void Start()
    {
        muzzlee = transform.GetChild(1);
        slider.maxValue = health;
        slider.value = health;
        startPos1 = platform.transform.position;
        zaman = 1;

    }

    // Update is called once per frame
    void Update()
    {
        
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, startPos1, Time.deltaTime * speed);
        if (platform.transform.position == startPos1)
        {
            Vector3 templocalScale = transform.localScale;
            templocalScale.x *= -1;
            transform.localScale = templocalScale;
            startPos1 = startPos2;
            if (startPos1 == startPos2)
            {
               
                startPos2 = platform.transform.position;
            }
        }
        zaman -= Time.deltaTime;
        if (zaman<=0)
        {
            zaman = 1;
            FireBullet();
        }
        
 

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !coliderBusy)
        {
            coliderBusy = true;
            other.GetComponent<PlayerManager>().GetDamage(damage);
        }
        else if (other.tag == "Bullet")
        {
            GetDamage(other.GetComponent<BulletManager>().bulletDamage);
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
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
            DataManager.Instance.BeeKilled++;
            GameObject patlama = Instantiate(PatlamaEffect, transform.position, Quaternion.identity);
            dead = true;
            float sure = patlama.GetComponent<ParticleSystem>().main.duration;
            Destroy(gameObject);
        }
    }

    public void FireBullet()
    {
        Transform tempBullet;
        tempBullet = Instantiate(firebullet, muzzlee.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzlee.forward * firebulletSpeed);
        
    }


}
