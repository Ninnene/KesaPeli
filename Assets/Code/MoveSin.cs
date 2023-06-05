using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSin : MonoBehaviour
{
    float sinCenterY;
    public float amplitude = 2;  // Siniaallon korkeus
    public float frequency = 2; // Siniaallon taajuus

    public bool inverted = false; // Käänteinen aalto

    // Start is called before the first frame update
    void Start()
    {
        sinCenterY = transform.position.y;
    }


    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        // Laitetaan vihulaiset liikkumaan ylös-alas siniaallon (Laskukaava löytyy Unityn sisältä Mathf.Sin) tahtiin

        float sin = Mathf.Sin(pos.x * frequency) * amplitude;
        if (inverted)
        {
            sin *= -1;
        }

        pos.y = sinCenterY + sin;

        transform.position = pos;
    }

}
