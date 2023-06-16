using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCode : MonoBehaviour
{
    
    public float hitpoints = 500;



    float timerRings = 0;
    float timer = 0;



    // IPK ampumisvaihe

    Vector3 spawnPosition;
    
    Vector3 moveTillUp;

    Vector3 moveTillDown;


    float iPKSpeed = 5;

    bool spawnIPK = true;

    float middleAttackDone = 0;

    bool attackMiddle = false;
    public float repeatMiddleAttack = 0;


    float cycleNumber = 0;


    // IPK ylös - alas - hyökkäysvaihe


    float bubbleSpeed = 0.3f;

    Vector3 bubbleStartPosition;
    bool startIPKUpDownAttack = false;

    bool startIPKDownUpAttack = false;

    public GameObject iPKUp;

    public GameObject iPKDown;

    public GameObject bubbles;


    float repeatUpDownAttack = 0;


    Vector3 iPKUpStartPosition;     // Aloituspiste

    Vector3 iPKDownStartPosition;   // Aloituspiste

    Vector3 iPKUpModdedPosition;    // Arvottu piste

    Vector3 iPKDownModdedPosition;  // Arvottu piste


    Vector3 iPKUpMoveTillRight = new Vector3(-0.49000001f,21.1800003f,-14.04f);

    Vector3 iPKDownMoveTillLeft = new Vector3(18.5400009f,-11.5900002f,-14.04f);

    Vector3 attackPositionStart = new Vector3(24.3f,5.07f,-5.236f);


    bool attackUp = false;
    bool attackDown = false;


    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;  // IPK ampumisvaiheen aloituspaikka

        iPKUpStartPosition = iPKUp.transform.position;  // IPK ylhääällä aloituspaikka

        iPKUpModdedPosition = iPKUp.transform.position;  // IPK ylhäällä arvontapaikka

        iPKDownStartPosition = iPKDown.transform.position;  //  IPK alhaalla aloituspaikka

        iPKDownModdedPosition = iPKDown.transform.position; // IPK alhaalla arvontapaikka


        bubbleStartPosition = bubbles.transform.position;   // Kuplien aloituspaikka
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnIPK == true)
        {
        transform.position = Vector3.MoveTowards(transform.position, attackPositionStart, iPKSpeed * Time.deltaTime);
        }

        Debug.Log("In attack position");


    if (transform.position == attackPositionStart && !attackMiddle)
    {
    spawnIPK = false;

    Debug.Log("Starting middle attack");

    attackMiddle = true;

    StartCoroutine(AttackMiddle()); // start the coroutine
    }


    
    if (startIPKUpDownAttack == true)
    {
    StartCoroutine(AttackUpDown()); // start the second coroutine
    }

    if (startIPKDownUpAttack == true && startIPKUpDownAttack == false )
    {
    StartCoroutine(AttackDownUp());
    }

    }

    

    IEnumerator AttackMiddle()
    {    

        Debug.Log("Start Attack from middle");

        attackMiddle = false;

        // Aktivoidaan aseet. (cycleNumber) ;

        gameObject.transform.GetChild(0).gameObject.SetActive(true);

        if (cycleNumber >=2)
        {
            Debug.Log("Activate weapon 2");
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }




        while (repeatMiddleAttack <10)
        {

        repeatMiddleAttack++;

        moveTillUp = new Vector3(24.2999992f,10.1800003f,-5.23600006f);

       // Debug.Log("moveTillUp = " + moveTillUp);

        while (transform.position != moveTillUp)
        {
        transform.position = Vector3.MoveTowards(transform.position, moveTillUp, iPKSpeed * Time.deltaTime);
        yield return null;
        }
            
            
            
        if(transform.position == moveTillUp)
        
        moveTillDown = new Vector3(24.2999992f,1.71000004f,-5.23600006f);

      //  Debug.Log("moveTillDown = " + moveTillDown);

        while (transform.position != moveTillDown)
        {
        transform.position = Vector3.MoveTowards(transform.position, moveTillDown, iPKSpeed * Time.deltaTime);
        yield return null;
        }
            if(transform.position == moveTillDown)
        {
        repeatMiddleAttack++;

       // Debug.Log("Repeat is : " + repeatMiddleAttack);


        if (repeatMiddleAttack >=10)
        {
        
      //  Debug.Log("Return to spawnposition");


            // Deaktivoidaan aseet :

        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
        gameObject.transform.GetChild(4).gameObject.SetActive(false);
        gameObject.transform.GetChild(5).gameObject.SetActive(false);
        gameObject.transform.GetChild(6).gameObject.SetActive(false);

        while (transform.position != spawnPosition)
        {
        transform.position = Vector3.MoveTowards(transform.position, spawnPosition, iPKSpeed * Time.deltaTime);
        yield return null;
        }
        
            if(transform.position == spawnPosition && repeatMiddleAttack >= 10)
            {
            ++middleAttackDone;

            startIPKUpDownAttack = true;

            cycleNumber++;

            Debug.Log("Cyclenumber = " + cycleNumber);

            //Debug.Log("Yield break!" + middleAttackDone);
            yield break;
            }
        }
        }
        }
    }

    

            /* // Tässä on koodi joka liikuttaa IPK-yläkalaa kerran vasemmalle + oikealle

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
                    Debug.Log("Start Attack from up");
                    
                    repeatMiddleAttack = 0;

                    ++repeatUpDownAttack;


                    startIPKUpDownAttack = false; // Tämä pitää asettaa falseksi ettei AttackUpDown() aktivoidu koko ajan update-metodissa.

                   
                   // Arvotaan yläkalan ja kuplien positio :
                   
                   // Debug.Log("iPKUp:in positio on = " + iPKUpStartPosition);
                    
                   // Debug.Log("Start AttackUpDown");

                    iPKUpModdedPosition = new Vector3(Random.Range(iPKUpModdedPosition.x - 0.10f, iPKUpModdedPosition.x + 14), Random.Range(iPKUpModdedPosition.y - 0, iPKUpModdedPosition.y + 0),Random.Range(iPKUpModdedPosition.z - 0f, iPKUpModdedPosition.z +0 ));

                    iPKUp.transform.position = iPKUpModdedPosition;

                    bubbles.transform.position = iPKUpModdedPosition;
                    

                 //   Debug.Log("iPKUp:in positio on = " + iPKUpStartPosition);


                    // Tuotetaan varoituskuplat :


                    while (bubbles.transform.position.y > -0.0246f)
                    {
                  //      Debug.Log("Bubbles");

                        Vector3 position = bubbles.transform.position;

                        position.y -= bubbleSpeed * Time.fixedDeltaTime;

                        bubbles.transform.position = position;

                        yield return null;
                    }

                    // Laitetaan yläkala hyökkäämään kun kuplat ovat alhaalla :


                    while (iPKUp.transform.position.y > -8.15f && bubbles.transform.position.y > -8.15)
                    {
                        repeatUpDownAttack++;

                        bubbles.transform.position = bubbleStartPosition;

                    //    Debug.Log("Start AttackUpDown");

                        Vector3 position = iPKUp.transform.position;

                        position.y -= iPKSpeed * Time.fixedDeltaTime;

                        iPKUp.transform.position = position;


                        
                        
                        yield return null;
                    }

                    iPKUp.transform.position = iPKUpStartPosition;

                    iPKUpModdedPosition = iPKUpStartPosition;

                    startIPKDownUpAttack = true;
                }

                    
                    IEnumerator AttackDownUp()
                    {
                    
                        Debug.Log("Start attack from down");


                     ++repeatUpDownAttack;


                    startIPKDownUpAttack = false;  // Tämä pitää asettaa falseksi ettei AttackDownUp() aktivoidu koko ajan update-metodissa.

                        // Arvotaan alakalan ja kuplien positio:

                        iPKDownModdedPosition = new Vector3(Random.Range(iPKDownModdedPosition.x  +14f, iPKDownModdedPosition.x - 0.10f), Random.Range(iPKDownModdedPosition.y - 0, iPKDownModdedPosition.y + 0),Random.Range(iPKDownModdedPosition.z - 0f, iPKDownModdedPosition.z +0 ));

                        iPKDown.transform.position = iPKDownModdedPosition;

                        bubbles.transform.position = iPKDownModdedPosition;
                        
                 //       Debug.Log("Bubbles from down" + bubbles.transform.position);

                      //  Debug.Log("Alakalan positio on = " + iPKDownStartPosition);

                        

                    // Tuotetaan varoituskuplat :

                        while (bubbles.transform.position.y < 15)
                        {
                         //   Debug.Log("Bubbles from down" + bubbles.transform.position);

                            Vector3 position = bubbles.transform.position;

                            position.y += bubbleSpeed * Time.fixedDeltaTime;

                            bubbles.transform.position = position;

                        //    Debug.Log("Does bubbles transform change?" + bubbles.transform.position);

                            yield return null;
                        }


                        bubbles.transform.position = bubbleStartPosition;

                     // Laitetaan alakala hyökkäämään kun kuplat ovat alhaalla :


                        while (iPKDown.transform.position.y < 17.91f && bubbles.transform.position == bubbleStartPosition)

                        {

                            Debug.Log("Start AttackDownUp");
 

                            Vector3 position = iPKDown.transform.position;

                            position.y += iPKSpeed * Time.fixedDeltaTime;

                            iPKDown.transform.position = position;
                            

                           // startIPKDownUpAttack = false;
                            yield return null;
                        }

                        // Jos kaikki alla olevat ehdot asetetaan rupeaa keskuskala ampumaan sekä ylä- ja alakala hyökkäämään loputtomasti :
                        
                        //transform.position = attackPositionStart;
                        //attackMiddle = false;
                        //startIPKUpDownAttack = false;

                        //startIPKDownUpAttack = false; 
                        //startIPKUpDownAttack = true;

                        iPKDown.transform.position = iPKDownStartPosition;


                        spawnIPK = true;
                        attackMiddle = false;

                        iPKDownModdedPosition = iPKDownStartPosition;


                        if (repeatUpDownAttack > 10)
                            {
                            Debug.Log("STOP!");
                            
                            }

                    }


    
        // Collisionit :

        private void OnTriggerEnter(Collider collision)
        {
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            --hitpoints;

            if (!bullet.isEnemy)
            {
                

                if (hitpoints <= 0)
                {
                Destroy(gameObject);
                Destroy(bullet.gameObject);
            }
            }
            
        }
        }
        




} 
