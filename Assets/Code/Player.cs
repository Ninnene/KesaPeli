using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{
    //Array of guns :p
    Gun[] guns;

//Liikkumisen ja kääntymisen nopeudet:
    public float moveSpeed = 3;
    public float turnSpeed = 20;

// Kääntymisen nollaus
    private float timer = 0f;
    public float resetTime = 0.2f;
    private bool isRotating = false;
    public float maxRotation = 45f;

// Perusliikkuminen, "juoksu" ja ampuminen
    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;

    bool speedUp;

    bool shoot;

    //Kilpi
    GameObject shield;
    int powerUpGunLevel = 0;
   


    void Start()
    {   
        
        shield = transform.Find("Shield").gameObject;
        DeactivateShield();


        // Kun Player luodaan sceneen etsitään kaikki aseet jotka ovat siinä kiinni (in children)
        guns = transform.GetComponentsInChildren<Gun>();
        foreach (Gun gun in guns)
        {
            gun.isActive = true;

            if (gun.powerUpLeveleRequirement != 0)
            {
                gun.gameObject.SetActive(false);
            }
        }
    }

   
    void Update()
    {
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

        speedUp = Input.GetKey(KeyCode.LeftShift)||Input.GetKey(KeyCode.RightShift);


        //Space ampuu kerran & LCTRL ampuu sarjaa. Tämä voidaan mahdollistaa esimerkiksi power-upilla.
        shoot = Input.GetKeyDown(KeyCode.Space)||Input.GetKey(KeyCode.LeftControl);
        if (shoot)
        {
            shoot = false;
            foreach(Gun gun in guns)
            {
                if(gun.gameObject.activeSelf)
                {
                gun.Shoot();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.fixedDeltaTime;
        if (speedUp)
    {
        moveAmount *= 3;
    }
        Vector2 move = Vector2.zero;




    if (moveUp)
    {
        move.y += moveAmount; 
        transform.rotation *= Quaternion.AngleAxis(turnSpeed * Time.deltaTime, Vector3.forward);   //Kala kääntyy kun se liikkuu ylöspäin
        
        if (gameObject.transform.eulerAngles.z > 60.0f)
        {
            gameObject.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 60.0f);
        }
        
        isRotating = true;
        timer = resetTime;
    }
        if(isRotating)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
            Quaternion targetRotation = Quaternion.Euler(0f, 90f, 0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * 10 * Time.deltaTime); //Kala kääntyy takaisin kohti vakiopistettä.
            if (transform.rotation == targetRotation) 
            {   
                isRotating = false;
            }
            }
        }
    


    if (moveDown)
    {
        move.y -= moveAmount; 
        transform.rotation *= Quaternion.AngleAxis(turnSpeed * Time.deltaTime, Vector3.back);   //Kala kääntyy kun se liikkuu alaspäin

        if (gameObject.transform.eulerAngles.z < 300.0f)
        {
            gameObject.transform.rotation = Quaternion.Euler(0.0f, 90.0f, -60.0f);
        }

        isRotating = true;
        timer = resetTime;
    }
        if(isRotating)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Quaternion targetRotation = Quaternion.Euler(0f, 90f, 0f);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * 10 * Time.deltaTime); //Kala kääntyy takaisin kohti vakiopistettä.
            
                    if (transform.rotation == targetRotation) 
                    {   
                        isRotating = false;
                    }
            }
        }



    if (moveLeft)
    {
        move.x -= moveAmount;
    }



    if (moveRight)
    {
        move.x += moveAmount;
    }


// Alla olevalla koodilla estetään liikkumisnopeuden kasvaminen jos liikutaan kahteen suuntaan yhtä aikaa:
    float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);
    if (moveMagnitude > moveAmount)
    {
        float ratio = moveAmount / moveMagnitude;
        move *= ratio;
    }
    moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);

    pos += move;




//Rajoitetaan liikkuminen kameran alueelle:
    if (pos.x <= 1.685599f )
    {
        pos.x = 1.685599f;
    }
    if (pos.x >= 15.6856f )
    {
        pos.x = 15.6856f;
    }

if (pos.y <= 1.159951f )
    {
        pos.y = 1.159951f;
    }
    if (pos.y >= 9.15995f )
    {
        pos.y = 9.15995f;
    }
    transform.position = pos;
    }


     // Kilpi
    void ActivateShield()
    {
        shield.SetActive(true);
    }
    void DeactivateShield()
    {
        shield.SetActive(false);
    }
    bool HasShield ()
    {
        return shield.activeSelf;
    }
        // Kilpi /


    //AsePowerUp;

     void AddGuns()
     {
        powerUpGunLevel++;
        foreach(Gun gun in guns)
        {
            if(gun.powerUpLeveleRequirement == powerUpGunLevel)
            {
                gun.gameObject.SetActive(true);
            }
        } 
     }

     void IncreaseSpeed()
     {
        moveSpeed *= 2;
     }

    private void OnTriggerEnter(Collider collision)
    {

        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            if (bullet.isEnemy)
            {
            Destroy(gameObject);
            Destroy(bullet.gameObject);
            }
        }

        Destructable destructable = collision.GetComponent<Destructable>();
        {
           if (destructable != null)
           {
            if (HasShield())
            {
                DeactivateShield();
            }
            else
            {
            Destroy(gameObject);
            }

            Destroy(destructable.gameObject);
            
           }
        }


        PowerUp powerUp = collision.GetComponent<PowerUp>();
        if (powerUp)
        {
            if (powerUp.activateShield)
            {
                ActivateShield();
            }
            if (powerUp.addGuns)
            {
                AddGuns();
            }
            if (powerUp.increaseSpeed)
            {
                IncreaseSpeed();
            }
            Destroy(powerUp.gameObject);
            
        }

    }
}
