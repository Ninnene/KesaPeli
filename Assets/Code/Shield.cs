using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
   public Renderer Renderer;

    void Start()
    {
        
    }

    void Update()
    {
        if (Renderer != null)
        {
            Renderer.enabled = !Renderer.enabled;
        }
    }
}
