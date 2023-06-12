using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullScript : MonoBehaviour
{
    // The target position to pull towards
    public Transform target;

    // The speed of pulling in units per second
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Calculate the maximum distance to move per frame
        float maxDistanceDelta = speed * Time.deltaTime;

        // Pull the target towards the object's position
        target.position = Vector3.MoveTowards(target.position, transform.position, maxDistanceDelta);
    }
}
