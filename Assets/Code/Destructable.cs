using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    bool canBeDestoyed = false;
    
    
    void Start()
    {
        
    }

    void Update()
    {
        if(transform.position.x < 20.15367)
        {
            canBeDestoyed = true;
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
