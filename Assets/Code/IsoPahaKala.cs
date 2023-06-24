using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoPahaKala : MonoBehaviour
{
    private Player playerScript;

    public float ipkSpeed = 5f;
    public float ipkLeft = 100f;
    public float ipkTimer = 1000f;
    public float ipkFiringTime = 100f;

        // Sini

        float sinCenterY;
        public float amplitude = 2;  // Siniaallon korkeus
        public float frequency = 2; // Siniaallon taajuus

        public bool inverted = false; // Käänteinen aalto

        // Sini /

     void Start()
    {
        sinCenterY = transform.position.y;
    }

    private void FixedUpdate()
    {

        ipkTimer -= 1f;

        if (ipkTimer <= 50)
        {
            Gun[] guns = transform.GetComponentsInChildren<Gun>();
            foreach (Gun gun in guns)
            {
            gun.isActive = true;  //tämä viittaa isActive booliin Gun-koodissa
            }
        }

        if (ipkTimer <=0)
        {
            Vector2 pos = transform.position;

            pos.x -= ipkSpeed * Time.fixedDeltaTime;

            ipkLeft -= 1f;

            if (pos.x <=11.0568)
            {
                ipkLeft = 0;
            }

             transform.position = pos;

            

        }
        if (ipkLeft <= 0)
        {
        
            ipkFiringTime -=1;
            if(ipkFiringTime <= 0)
            {
            IpkGoBack();
            }
        };
    }


    void IpkGoBack()
    {


        //Sini :
         Vector2 pos = transform.position;

        // Laitetaan vihulaiset liikkumaan ylös-alas siniaallon (Laskukaava löytyy Unityn sisältä Mathf.Sin) tahtiin

        float sin = Mathf.Sin(pos.x * frequency) * amplitude;
        if (inverted)
        {
            sin *= -1;
        }

        pos.y = sinCenterY + sin;

        transform.position = pos;

        //Sini /


        Gun[] guns = transform.GetComponentsInChildren<Gun>();
            foreach (Gun gun in guns)
            {
                gun.isActive = false;  //tämä viittaa isActive booliin Gun-koodissa
            }

        Vector2 sinPos = transform.position;

        pos.x += ipkSpeed * Time.fixedDeltaTime;

        ipkTimer += 10;

        if (pos.x > 25.0568f )
        {
            ipkTimer = +300;

            ipkLeft = 100;

            ipkFiringTime = 100;

            return;
        }

        transform.position = pos;


    }

    private void OnTriggerEnter(Collider collision)
    {   
        playerScript = GameObject.Find("PikkuKala").GetComponent<Player>();

        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
        FindObjectOfType<AudioManagerScript>().Play("dod"); //pelaaja kuolee ääni
            
        playerScript.ResetShip();
            
        }
    }
       
}
