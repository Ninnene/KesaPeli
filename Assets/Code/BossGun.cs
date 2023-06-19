using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGun : MonoBehaviour
{

    public int powerUpLeveleRequirement = 0;

    public Bullet bullet;
    Vector2 direction;

    public GameObject IPK;

    public Mesh shootMesh;
    public Mesh normalMesh;

    public float mouthTimer  = 0f;
    
// Enemy shooting variables

    public bool autoShoot = false;
    public float shootIntervalSeconds = 0.5f;
    public float shootDelay = 0.0f;
    float shootTimer = 0f;
    float delayTimer = 0f;
    
// Ase aktivoituu vain kun ehto Destructable-koodissa täyttyy
    public bool isActive = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        if (mouthTimer >0)
        {
            {
            mouthTimer -=Time.deltaTime;
            }

            if (mouthTimer <= 0)
            {
                IPK.gameObject.GetComponent<MeshFilter>().mesh = normalMesh;
            }
        }

        if (!isActive)
        {
            return;
        }


        direction = (transform.localRotation * Vector2.right).normalized;

        // Autoshoot :

        if (autoShoot)
       {
            //IPK.gameObject.GetComponent<MeshFilter>().mesh = normalMesh;
            
            if (delayTimer >= shootIntervalSeconds)
            {
                if(shootTimer >= shootIntervalSeconds)
                {
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

        IPK.gameObject.GetComponent<MeshFilter>().mesh = shootMesh;
        mouthTimer = 0.3f;


    }

}

