using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoPahaKala : MonoBehaviour
{

    public float ipkSpeed = 5f;
    public float ipkLeft = 100f;
    public float ipkTimer = 1000f;
    public float ipkFiringTime = 100f;

    private void FixedUpdate()
    {

        ipkTimer -= 1f;

        if (ipkTimer <=0)
        {
             Gun[] guns = transform.GetComponentsInChildren<Gun>();
            foreach (Gun gun in guns)
            {
                gun.isActive = true;  //tämä viittaa isActive booliin Gun-koodissa
            }

            Vector2 pos = transform.position;

            pos.x -= ipkSpeed * Time.fixedDeltaTime;

            ipkLeft -= 1f;

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

        Gun[] guns = transform.GetComponentsInChildren<Gun>();
            foreach (Gun gun in guns)
            {
                gun.isActive = false;  //tämä viittaa isActive booliin Gun-koodissa
            }

        Vector2 pos = transform.position;

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

        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            Destroy(player.gameObject);
        }
    }
       
}
