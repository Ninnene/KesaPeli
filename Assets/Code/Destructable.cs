using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Destructable : MonoBehaviour
{
    bool canBeDestoyed = false;
    public int scoreValue = 100;
    
    
    void Start()
    {
     LevelController.instance.AddDestructable();  //Tällä haetaan LevelController-koodi (Sen alussa on kohta "Private void Awake: instance this;" )
    }

    // Ase ei ole aktiivinen ennen kuin se on ruudulla

    void Update()
    {
        if (transform.position.x <-3)
        {
            LevelController.instance.RemoveDestructable();
            Destroy(gameObject);
        }


        if(transform.position.x < 20.15367 && !canBeDestoyed)
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
            LevelController.instance.AddScore(scoreValue); 
            LevelController.instance.RemoveDestructable();
            Destroy(gameObject);
            Destroy(bullet.gameObject);
            
            }
            
        }
    }

        
}
