using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health, bulletSpeed;
    bool dead = false;
    Transform muzzle;
    public Transform bullet, floatingtext;
    public Slider slider;
    bool mouseIsNotOverUI;
    public GameObject bloodParticle,CoinEfect;
   
    public static PlayerManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        muzzle = transform.GetChild(1);
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;
        Instance = this;
       // MouseShootBullet();

    }

    public void MouseShootBullet()
    {
        if (Input.GetMouseButtonDown(0) && mouseIsNotOverUI)
        {
            ShootBullet();
        }
    }

    public void GetDamage(float damage)
    {
        Instantiate(floatingtext, transform.position, Quaternion.identity).GetComponent<TextMesh>().text=damage.ToString();

        if((health- damage)>=0)
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
        if(health<=0)
        {

            GameObject patlama = Instantiate(bloodParticle, transform.position, Quaternion.identity);
            dead = true;
            float sure = patlama.GetComponent<ParticleSystem>().main.duration;
            DataManager.Instance.Yokolma();
           // Destroy(gameObject);
            gameObject.SetActive(false);
            MenuManagerInGameScene.Instance.backgroundsound.SetActive(false);
            MenuManagerInGameScene.Instance.InGameScreen.SetActive(false);
        }
    }



    public  void ShootBullet()
    {
        Transform tempBullet;
        tempBullet= Instantiate(bullet, muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward*bulletSpeed);
        DataManager.Instance.ShotBullet++;
    }

    private void OnTriggerEnter2D(Collider2D col)    //Player Coin algılaması
    {
        if (col.CompareTag("coin"))
        {
            Destroy(col.gameObject);
            DataManager.Instance.CollectCoin++;
            GameObject patlama = Instantiate(CoinEfect, transform.position, Quaternion.identity);
            dead = true;
            float sure = patlama.GetComponent<ParticleSystem>().main.duration;

        }

         if (col.tag == "Firebullet")
        {
            GetDamage(col.GetComponent<EnemyBullet>().firebulletDamage);
            Destroy(col.gameObject);
        }
         if(col.CompareTag("Winner"))
        {
            MenuManagerInGameScene.Instance.backgroundsound.SetActive(false);
            DataManager.Instance.Kazanma();
            WinEffect.Instance.kazanmaefek();
        }


    }



}
