using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightLeft : MonoBehaviour
{
    
    public float moveSpeed = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {

        //Luodaan ensin muuttuja, (Vector2) "position"
        //Seuraavaksi yksinkertaisesti vähennetään (-=) "move speed" kappaleen position X:n arvosta jolloin kappale vaihtaa paikkaa ruudulla. FixedDeltaTime sitoo muistaakseni laskutoimituksen (*) ruudunpäitysnopeuteen.
        //Aktivoidaan muuttunut positio kolmannessa kohtaa

        Vector2 position = transform.position;

        position.x -= moveSpeed * Time.fixedDeltaTime;

        transform.position = position;

    }



}
