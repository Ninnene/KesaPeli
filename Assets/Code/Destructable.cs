using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Destructable : MonoBehaviour
{
    public float normalEnemyHitPoints = 1;
    bool canBeDestoyed = false;
    public int scoreValue = 100;
    Player player;
    
    
    void Start()
    {
     LevelController.instance.AddDestructable();  //Tällä haetaan LevelController-koodi (Sen alussa on kohta "Private void Awake: instance this;" )

     player = GameObject.Find("PikkuKala").GetComponent<Player>(); // Haetaan Player - koodi jotta voidaan lukea playerDeathMovementPaused.

     //Debug.Log("state of playerDeathMovement = " + player.playerDeathMovementPaused); // Haetaan Playeristä 


    }

    // Ase ei ole aktiivinen ennen kuin se on ruudulla

    void Update()
    {


        if (transform.position.x <-3 && player.playerDeathMovementPaused == false) // playerDeathMovementPaused jos pelaajan kuolinanimaatio on kesken (true) ei vihollista poisteta.
        {
            Debug.Log("Enemy position <3 & deathmovement = false");

            LevelController.instance.RemoveDestructable();
            Destroy(gameObject);
        }


        if(transform.position.x < 28.15367 && !canBeDestoyed)
        {
            canBeDestoyed = true;
            Gun[] guns = transform.GetComponentsInChildren<Gun>();
            foreach (Gun gun in guns)
            {
                gun.isActive = true;  //tämä viittaa isActive booliin Gun-koodissa
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
    
        //Debug.Log("Collision detected in original Destructable!");

        if(!canBeDestoyed)
        {
            return;
        }


        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            if (!bullet.isEnemy)
            {
                FindObjectOfType<AudioManagerScript>().Play("enemy damage"); // tämä aktivoi damage äänen

                if(normalEnemyHitPoints >0)
                {
                    --normalEnemyHitPoints;
                    Destroy(bullet.gameObject);
                    return;
                }
                    else
                    {
                    LevelController.instance.AddScore(scoreValue); 
                    LevelController.instance.RemoveDestructable();
                    Destroy(gameObject);
                    Destroy(bullet.gameObject);
                    }
            }
            
        }
    }

        
}
