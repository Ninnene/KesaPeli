using UnityEngine;

public class AttackPlayer : MonoBehaviour
{

    PauseMenuSCRIPT pauseMenuSCRIPT;
    bool pause = false;

    // Valitse kohde (Inspector)
    //public Transform target;
    public Transform target;

    // Liikkumisnopeus
    public float speed = 5f;

    
    void Update()
    {

        target = GameObject.Find("PikkuKala").GetComponent<Transform>();
        

        if (target != null)
        {
        // Calculate the maximum distance to move per frame
        float maxDistanceDelta = speed * Time.deltaTime;

        // Liikuta objetia (.this) päin kahdetta. (target.position)
        transform.position = Vector3.MoveTowards(transform.position, target.position, maxDistanceDelta);
        }

        if (!target )
        {
        speed = 0.2f;

        if (PauseMenuSCRIPT.GameIsPaused)
        {
            speed = 0;
        }

        Vector2 position = transform.position;

        position.x -= speed * Time.fixedDeltaTime;

        transform.position = position;

        if (position.x <-3)
        {
            Destroy(gameObject);
        }
        }

    }
}
