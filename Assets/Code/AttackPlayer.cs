using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    // The target position to move towards
    public Transform target;

    // The speed of movement in units per second
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Calculate the maximum distance to move per frame
        float maxDistanceDelta = speed * Time.deltaTime;

        // Move the object towards the target position
        transform.position = Vector3.MoveTowards(transform.position, target.position, maxDistanceDelta);
    }
}
