using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoPahaKala : MonoBehaviour
{

    public float ipkSpeed = 5f;
    public float ipkLeft = 100f;
    public float ipkTimer = 1000f;

    private void FixedUpdate()
    {
        ipkTimer -= 1f;

        if (ipkTimer <=0)
        {
            Vector2 pos = transform.position;

            pos.x -= ipkSpeed * Time.fixedDeltaTime;

            ipkLeft -= 1f;

             transform.position = pos;

        }
        if (ipkLeft <= 0)
        {
            IpkGoBack();
        }
    }

    void IpkGoBack()
    {

        Vector2 pos = transform.position;

        pos.x += ipkSpeed * Time.fixedDeltaTime;

        ipkTimer += 10;

        if (pos.x > 25.0568f )
        {
            ipkTimer = +300;

            ipkLeft = 100;

            return;
        }

        transform.position = pos;

    }


       
}
