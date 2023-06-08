using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Bullet bullet;
    Vector2 direction;
    
// Enemy shooting variables

    public bool autoShoot = false;
    public float shootIntervalSeconds = 0.5f;
    public float shootDelay = 0.0f;
    float shootTimer = 0f;
    float delayTimer = 0f;
    
// Enemy shooting variables /


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction = (transform.localRotation * Vector2.right).normalized;

        // Autoshoot :

        if (autoShoot)
       {
            if (delayTimer >= shootIntervalSeconds)
            {
                if(shootTimer >= shootIntervalSeconds)
                {
                    Debug.Log("Shooty!");
                    Shoot();
                    shootTimer = 0;
                }
                else
                {
                    shootTimer += Time.deltaTime;
                }
            }
            else
            {
                delayTimer += Time.deltaTime;
            }
       }
    }

        // Autoshoot /

    public void Shoot()
    {
        //Luoti luodaan samaan paikkaan missä Gun on 
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        Bullet goBullet = go.GetComponent<Bullet>();
        goBullet.direction = direction;
    }

}
