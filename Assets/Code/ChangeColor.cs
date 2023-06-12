using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public GameObject myGameObject;
    

    // Start is called before the first frame update
    public void ActivateColorChange() 
    {
    Debug.Log ("changing material");
    // Change the material of the game object here
    myGameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }
    
}











