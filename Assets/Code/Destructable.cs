using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    bool canBeDestoyed = false;
    
    
    void Start()
    {
        
    }

    // Ase ei ole aktiivinen ennen kuin se on ruudulla

    void Update()
    {
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
    
        if(!canBeDestoyed)
        {
            return;
        }

        Debug.Log("Pam!");

        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            if (!bullet.isEnemy)
            {
            Destroy(gameObject);
            Destroy(bullet.gameObject);
            }
            
        }
    }


}
