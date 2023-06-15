using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCode : MonoBehaviour
{

    // IPK ampumisvaihe

    Vector3 spawnPosition;
    Vector3 attackPositionStart;

    Vector3 moveTillUp;

    Vector3 moveTillDown;

    float iPKSpeed = 5;

    bool spawnIPK = true;

    float middleAttackDone = 0;

    bool attackMiddle = false;
    public float repeatMiddleAttack = 8;



    // IPK ylös - alas - hyökkäysvaihe

    bool startIPKUpDownAttack = false;

    public GameObject iPKUp;

    public GameObject iPKDown;


    float repeatUpDownAttack = 0;


    Vector3 iPKUpStartPosition;

    Vector3 iPKDownStartPosition;



    Vector3 iPKUpMoveTillRight = new Vector3(-0.49000001f,21.1800003f,-14.04f);

    Vector3 iPKDownMoveTillLeft = new Vector3(18.5400009f,-11.5900002f,-14.04f);

    


    bool attackUp = false;
    bool attackDown = false;


    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;  // IPK ampumisvaiheen aloituspaikka

        iPKUpStartPosition = iPKUp.transform.position;  // IPK ylhääällä aloituspaikka

        iPKDownStartPosition = iPKDown.transform.position;  // IPK alhaalla aloituspaikka
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnIPK == true)
        {
        attackPositionStart = new Vector3(24.3f,5.07f,-5.236f);

        transform.position = Vector3.MoveTowards(transform.position, attackPositionStart, iPKSpeed * Time.deltaTime);
        }


    if (transform.position == attackPositionStart && !attackMiddle)
    {
    
    spawnIPK = false;

    Debug.Log("spawnIPK = " + spawnIPK);

    attackMiddle = true;

    StartCoroutine(AttackMiddle()); // start the coroutine
    }
    
    if (startIPKUpDownAttack == true)
    {
    StartCoroutine(AttackUpDown()); // start the second coroutine
    }



    }

    

    IEnumerator AttackMiddle()
    {    

        Debug.Log("Start AttackMiddle");

        gameObject.transform.GetChild(0).gameObject.SetActive(true);

        while (repeatMiddleAttack <10)
        {

        repeatMiddleAttack++;

        moveTillUp = new Vector3(24.2999992f,10.1800003f,-5.23600006f);

        Debug.Log("moveTillUp = " + moveTillUp);

        while (transform.position != moveTillUp)
        {
        transform.position = Vector3.MoveTowards(transform.position, moveTillUp, iPKSpeed * Time.deltaTime);
        yield return null;
        }
            
            
            
        if(transform.position == moveTillUp)
        
        moveTillDown = new Vector3(24.2999992f,1.71000004f,-5.23600006f);

        Debug.Log("moveTillDown = " + moveTillDown);

        while (transform.position != moveTillDown)
        {
        transform.position = Vector3.MoveTowards(transform.position, moveTillDown, iPKSpeed * Time.deltaTime);
        yield return null;
        }
            if(transform.position == moveTillDown)
        {
        repeatMiddleAttack++;

        Debug.Log("Repeat is : " + repeatMiddleAttack);


        if (repeatMiddleAttack >=10)
        {
        
        Debug.Log("Return to spawnposition");

        gameObject.transform.GetChild(0).gameObject.SetActive(false);

        while (transform.position != spawnPosition)
        {
        transform.position = Vector3.MoveTowards(transform.position, spawnPosition, iPKSpeed * Time.deltaTime);
        yield return null;
        }
        
            if(transform.position == spawnPosition && repeatMiddleAttack >= 10)
            {
            ++middleAttackDone;

            startIPKUpDownAttack = true;

            Debug.Log("Yield break!" + middleAttackDone);
            yield break;
            }
        }
        }
        }
    }

    

            /*  Tässä on koodi joka liikuttaa IPK-yläkalaa kerran vasemmalle + oikealle



                IEnumerator AttackUpDown()
                {
                    startIPKUpDownAttack = false;
                    
                    Debug.Log("Start AttackUpDown");

                
                    while (repeatUpDownAttack < 10)
                    {

                        while (iPKUp.transform.position != iPKUpMoveTillRight)
                            {
                                iPKUp.transform.position = Vector3.MoveTowards(iPKUp.transform.position, iPKUpMoveTillRight, iPKSpeed * Time.deltaTime);
                                repeatUpDownAttack++;
                                yield return null;
                            }

                        while (iPKUp.transform.position != iPKUpStartPosition)
                            {
                                iPKUp.transform.position = Vector3.MoveTowards(iPKUp.transform.position, iPKUpStartPosition, iPKSpeed * Time.deltaTime);
                                repeatUpDownAttack++;
                                yield return null;
                            }

                        if (repeatUpDownAttack >= 10)
                        {
                        yield break;
                        }

                    }
                    
            */

                IEnumerator AttackUpDown()
                {
                    startIPKUpDownAttack = false;

                    Debug.Log("iPKUp:in positio on = " + iPKUpStartPosition);
                    
                    Debug.Log("Start AttackUpDown");

                    iPKUpStartPosition = new Vector3(Random.Range(iPKUpStartPosition.x - 0.10f, iPKUpStartPosition.x + 0), Random.Range(iPKUpStartPosition.y - 0, iPKUpStartPosition.y + 0),Random.Range(iPKUpStartPosition.z - 0f, iPKUpStartPosition.z +0 ));

                    iPKUp.transform.position = iPKUpStartPosition;

                    Debug.Log("iPKUp:in positio on = " + iPKUpStartPosition);

                    while (iPKUp.transform.position.y > -8.15f)
                    {
                        Debug.Log("Start AttackUpDown");

                        Vector3 position = iPKUp.transform.position;

                        position.y -= iPKSpeed * Time.fixedDeltaTime;

                        transform.position = position;

                        yield return null;
                    }

                    if (repeatUpDownAttack >= 10)
                        {
                        yield break;
                        }

                }




} 




/*
iPKDownStartPosition;



    Vector3 VectoriPKUpMoveTillRight



    iPKUpStartPosition
    */