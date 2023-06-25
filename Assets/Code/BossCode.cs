using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossCode : MonoBehaviour
{
    Player playerScript; // Luodaan playerScript jonka avulla kutsutaan pomon kuollessa Player-koodista FadeImage() - metodia.
    //int fadeDuration = 3; Saako FadeImage() kutsuttua fadeDuration-muuttujaa niin, että sitä ei tarvita tässä?
    [SerializeField] FloatingHealthBar healthBar; //Ui HP slideri tähän
    
    [SerializeField] public float hitpoints;
    [SerializeField] public float maxHP = 500;
    public float currentHp;

    bool canBeDestoyed = false;

    public Renderer Renderer;

    public Mesh normalIPK;

    // IPK ampumisvaihe

    Vector3 spawnPosition;
    
    Vector3 moveTillDown = new Vector3(24.2999992f,1.71000004f,-5.23600006f);

    Vector3 moveTillUp = new Vector3(24.2999992f,11.2800003f,-5.23600006f);

    float iPKSpeed = 5;

    float iPKDeathSpeed = 2;

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

    Vector3 iPKUpModdedPosition;    // Arvottu piste    (RandomRange)

    Vector3 iPKDownModdedPosition;  // Arvottu piste    (RandomRange)


    Vector3 moveDownVector; // Kala liikkuu arvotun pisteen jälkeen tänne


    Vector3 iPKUpMoveTillRight = new Vector3(-0.49000001f,21.1800003f,-14.04f);

    Vector3 iPKDownMoveTillLeft = new Vector3(18.5400009f,-11.5900002f,-14.04f);

    Vector3 attackPositionStart = new Vector3(24.3f,5.07f,-5.236f);

    Vector3 deathPosition = new Vector3(20.2900009f,-4.4000001f,-5.23600006f);

    public bool pleasePause = false;
    

    private void Awake() // Awake metodi jotta voidaan käyttää HP palkkia
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }
    void Start()
    {

        spawnPosition = transform.position;  // IPK ampumisvaiheen aloituspaikka

        iPKUpStartPosition = iPKUp.transform.position;  // IPK ylhääällä aloituspaikka

        iPKUpModdedPosition = iPKUp.transform.position;  // IPK ylhäällä arvontapaikka

        iPKDownStartPosition = iPKDown.transform.position;  //  IPK alhaalla aloituspaikka

        iPKDownModdedPosition = iPKDown.transform.position; // IPK alhaalla arvontapaikka


        bubbleStartPosition = bubbles.transform.position;   // Kuplien aloituspaikka
        
        hitpoints = maxHP;
        healthBar = GetComponentInChildren<FloatingHealthBar>();


    }


    
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Escape) && pleasePause == false)
        {
            pleasePause = true;   
            Debug.Log("Pause = " + pleasePause);   
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pleasePause == true)
        {
            pleasePause = false;  
            Debug.Log("Pause = " + pleasePause);
        }
        */

        


        if (hitpoints <= 0) 
            {
                
               StartCoroutine(BossDeath());
            }


        if(spawnIPK == true)
        {
        transform.position = Vector3.MoveTowards(transform.position, attackPositionStart, iPKSpeed * Time.deltaTime);
        }

       // Debug.Log("In attack position");



        // Estetään pomon vahingoittaminen jos se ei ole hyökkäysasennossa :

        if(transform.position == attackPositionStart)
        {
            canBeDestoyed = true;

            Debug.Log(" (Boss) Can be destroyed = " + canBeDestoyed);
           
        }


    if (transform.position == attackPositionStart && canBeDestoyed && hitpoints >0)
    {
    spawnIPK = false;

    //Debug.Log("Fetch middle attack");

    attackMiddle = true;

    StartCoroutine(AttackMiddle());
    }
    if (startIPKUpDownAttack == true && hitpoints >0)
    {

    
    //Debug.Log("Fetch up attack");
    StartCoroutine(AttackUpDown()); 
    }
    if (startIPKDownUpAttack == true && startIPKUpDownAttack == false && hitpoints >0)
    {
    //Debug.Log("Fetch down attack");
    
    StartCoroutine(AttackDownUp());
    }


    

    }


     // Collisionit :

        private void OnTriggerEnter(Collider collision)
    {
        if(!canBeDestoyed)
        {
            return;
        }


        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            if (!bullet.isEnemy)
            {FindObjectOfType<AudioManagerScript>().Play("enemy damage"); // tämä aktivoi vihun damage äänen

                --hitpoints;
                //currentHp = maxHP - hitpoints;
                healthBar.UpdateHealthBar(hitpoints, maxHP);
                Destroy(bullet.gameObject);
            }
            
                
        }
    }




    IEnumerator AttackMiddle()
    {    
        
        Debug.Log("Start Attack from middle");

        attackMiddle = false;

        // Aktivoidaan aseet. (cycleNumber) ;

        gameObject.transform.GetChild(0).gameObject.SetActive(true);

        if (cycleNumber >=1)
        {
            Debug.Log("Activate weapon 2");
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (cycleNumber >=4)
        {
            Debug.Log("Activate weapon 3");
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }

        if (cycleNumber >=6)
        {
            Debug.Log("Activate weapon 4");
            gameObject.transform.GetChild(3).gameObject.SetActive(true);
        }



        while ( hitpoints >0)
        {

       // Debug.Log("moveTillUp = " + moveTillUp);

        while (transform.position != moveTillUp && hitpoints >0)
        {
        transform.position = Vector3.MoveTowards(transform.position, moveTillUp, iPKSpeed * Time.deltaTime);
        yield return null;
        }
            

      //  Debug.Log("moveTillDown = " + moveTillDown);

        while (transform.position != moveTillDown && hitpoints >0)
        {
        transform.position = Vector3.MoveTowards(transform.position, moveTillDown, iPKSpeed * Time.deltaTime);
        yield return null;
        }
            if(transform.position == moveTillDown)
        {
        repeatMiddleAttack++;

       // Debug.Log("Repeat is : " + repeatMiddleAttack);


        if (repeatMiddleAttack >=4)
        {
        
        Debug.Log("Return to spawnposition");

        Debug.Log("Start deactivate weapons");
            // Deaktivoidaan aseet :

        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
        gameObject.transform.GetChild(4).gameObject.SetActive(false);
        gameObject.transform.GetChild(5).gameObject.SetActive(false);
        gameObject.transform.GetChild(6).gameObject.SetActive(false);

        Debug.Log("Weapons deactivated");

        while (transform.position != spawnPosition && hitpoints >0)
        {
        transform.position = Vector3.MoveTowards(transform.position, spawnPosition, iPKSpeed * Time.deltaTime);
        gameObject.GetComponent<MeshFilter>().mesh = normalIPK;
        yield return null;

        
        }
        
            if(transform.position == spawnPosition && repeatMiddleAttack >= 4 && hitpoints >0)
            {
            ++middleAttackDone;

            cycleNumber++;

            Debug.Log("Cyclenumber = " + cycleNumber);

            startIPKUpDownAttack = true;

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

                
                    Debug.Log("AttackUpDown()");

                    canBeDestoyed = false;

                    Debug.Log("Start Attack from up");
                    
                    repeatMiddleAttack = 0;

                    ++repeatUpDownAttack;


                    startIPKUpDownAttack = false; // Tämä pitää asettaa falseksi ettei AttackUpDown() aktivoidu koko ajan update-metodissa.

                   
                   // Arvotaan yläkalan ja kuplien positio :
                   
                   // Debug.Log("iPKUp:in positio on = " + iPKUpModdedPosition);
                    
                   // Debug.Log("Start AttackUpDown");

                    iPKUpModdedPosition = new Vector3(Random.Range(iPKUpModdedPosition.x - 0.10f, iPKUpModdedPosition.x + 14), Random.Range(iPKUpModdedPosition.y - 0, iPKUpModdedPosition.y + 0),Random.Range(iPKUpModdedPosition.z - 0f, iPKUpModdedPosition.z +0 ));

                    iPKUp.transform.position = iPKUpModdedPosition;

                    bubbles.transform.position = iPKUpModdedPosition;
                    

                 //   Debug.Log("iPKUp:in positio on = " + iPKUpModdedPosition);


                    // Tuotetaan varoituskuplat :
                    Vector3 moveDownVector = new Vector3(iPKUpModdedPosition.x, iPKUpModdedPosition.y - 30f, iPKUpModdedPosition.z);
                    
                    while (bubbles.transform.position != moveDownVector && hitpoints >0)
                    {
                    bubbles.transform.position = Vector3.MoveTowards(bubbles.transform.position, moveDownVector, iPKSpeed * 2.5f * Time.deltaTime);
                    yield return null;
                    }

                    
                    while (iPKUp.transform.position != moveDownVector && hitpoints >0)
                    {
                    iPKUp.transform.position = Vector3.MoveTowards(iPKUp.transform.position, moveDownVector, iPKSpeed * 5 * Time.deltaTime);
                    yield return null;
                    }
                    /*
                    while (bubbles.transform.position.y > -0.0246f)
                    {
                  //      Debug.Log("Bubbles");

                        Vector3 position = bubbles.transform.position;

                        position.y -= bubbleSpeed * Time.fixedDeltaTime;

                        bubbles.transform.position = position;

                        
                        yield return null;
                        
                    }*/

                    // Laitetaan yläkala hyökkäämään kun kuplat ovat alhaalla :


                    while (iPKUp.transform.position.y > -8.15f && bubbles.transform.position == moveDownVector)
                    {
                        repeatUpDownAttack++;

                        bubbles.transform.position = bubbleStartPosition;

                    //    Debug.Log("Start AttackUpDown");

                        Vector3 position = iPKUp.transform.position;

                        position.y -= iPKSpeed * Time.fixedDeltaTime;

                        iPKUp.transform.position = position;

                         
                        yield return null;
                        
                    }

                    // Valmistellaan seuraava vaihe :

                    iPKUp.transform.position = iPKUpStartPosition;

                    iPKUpModdedPosition = iPKUpStartPosition;

                    startIPKDownUpAttack = true;
                }

                    
                    IEnumerator AttackDownUp()
                    {   

                        Debug.Log("AttackDownUp()");

                        canBeDestoyed = false;


                     ++repeatUpDownAttack;


                    startIPKDownUpAttack = false;  // Tämä pitää asettaa falseksi ettei AttackDownUp() aktivoidu koko ajan update-metodissa.

                        // Arvotaan alakalan ja kuplien positio:

                        iPKDownModdedPosition = new Vector3(Random.Range(iPKDownModdedPosition.x  +14f, iPKDownModdedPosition.x - 0.10f), Random.Range(iPKDownModdedPosition.y - 0, iPKDownModdedPosition.y + 0),Random.Range(iPKDownModdedPosition.z - 0f, iPKDownModdedPosition.z +0 ));

                        iPKDown.transform.position = iPKDownModdedPosition;

                        bubbles.transform.position = iPKDownModdedPosition;
                        
                 //       Debug.Log("Bubbles from down" + bubbles.transform.position);

                      //  Debug.Log("Alakalan positio on = " + iPKDownStartPosition);

                        
                    Vector3 moveDownVector = new Vector3(iPKDownModdedPosition.x, iPKDownModdedPosition.y + 30f, iPKDownModdedPosition.z);
                    
                    while (bubbles.transform.position != moveDownVector && hitpoints >0)
                    {
                    bubbles.transform.position = Vector3.MoveTowards(bubbles.transform.position, moveDownVector, iPKSpeed * 2.5f * Time.deltaTime);
                    yield return null;
                    }

                    
                    while (iPKDown.transform.position != moveDownVector && hitpoints >0)
                    {
                    iPKDown.transform.position = Vector3.MoveTowards(iPKDown.transform.position, moveDownVector, iPKSpeed * 5 * Time.deltaTime);
                    yield return null;
                    }



                    // Tuotetaan varoituskuplat :
                        /*
                        while (bubbles.transform.position.y < 15)
                        {
                         //   Debug.Log("Bubbles from down" + bubbles.transform.position);

                            Vector3 position = bubbles.transform.position;

                            position.y += bubbleSpeed * Time.fixedDeltaTime;

                            bubbles.transform.position = position;

                        //    Debug.Log("Does bubbles transform change?" + bubbles.transform.position);
                       
                    
                        yield return null;
                        
                        }
                            */

                        bubbles.transform.position = bubbleStartPosition;

                     // Laitetaan alakala hyökkäämään kun kuplat ovat ylhäällä :

                        /*
                        while (iPKDown.transform.position.y < 17.91f && bubbles.transform.position == bubbleStartPosition)
                        {

                            //Debug.Log("Start AttackDownUp");
 

                            Vector3 position = iPKDown.transform.position;

                            position.y += iPKSpeed * Time.fixedDeltaTime;

                            iPKDown.transform.position = position;
                            

                           // startIPKDownUpAttack = false;
                       
                        yield return null;
                        
                        }
                        */
                        // Jos kaikki alla olevat ehdot asetetaan rupeaa keskuskala ampumaan sekä ylä- ja alakala hyökkäämään loputtomasti :
                        
                        //transform.position = attackPositionStart;
                        //attackMiddle = false;
                        //startIPKUpDownAttack = false;

                        //startIPKDownUpAttack = false; 
                        //startIPKUpDownAttack = true;


                        // Asetetaan ehdot jotta vaihe voi alkaa alusta :

                        iPKDown.transform.position = iPKDownStartPosition;


                        spawnIPK = true;
                        attackMiddle = false;

                        iPKDownModdedPosition = iPKDownStartPosition;
                        

                    }
                    

             public IEnumerator BossDeath()
                {
                    gameObject.GetComponent<BoxCollider>().enabled = false;

                    Renderer.enabled =! Renderer.enabled;

                    gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(2).gameObject.SetActive(false);
                    gameObject.transform.GetChild(3).gameObject.SetActive(false);
                    gameObject.transform.GetChild(4).gameObject.SetActive(false);
                    gameObject.transform.GetChild(5).gameObject.SetActive(false);
                    gameObject.transform.GetChild(6).gameObject.SetActive(false);
                    gameObject.transform.GetChild(6).gameObject.SetActive(false);
                    gameObject.transform.GetChild(7).gameObject.SetActive(false);
            
                    

                    transform.position = Vector3.MoveTowards(transform.position, deathPosition, iPKDeathSpeed * Time.deltaTime);
                    transform.rotation *= Quaternion.AngleAxis(iPKSpeed * 10 * Time.deltaTime, Vector3.left);

                    while(transform.position == deathPosition)
                    {
                        
                        playerScript = GameObject.Find("PikkuKala").GetComponent<Player>();
                        playerScript.StartCoroutine("FadeImage");

                        Destroy(gameObject);  

                        yield return null;   
                    }
                    

                    
                }
                  
       
        




} 
