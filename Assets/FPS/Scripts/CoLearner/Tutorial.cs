using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    //to control wordBot Dialogue
    public GameObject dialogue;
    private DialogueManager dialogueManager;
    private int curScript; //which script we're on
    private int curPlaying = -1; //which tutorial scene is currently playing

    //to control wordBot movement
    public GameObject botAndGun;
    public GameObject wordBot;
    private animationController animationController;
    public GameObject botGun;
    private WordBotGun wbg;
    private Rigidbody botRB;

    //flags for animation
    private float lastShot = 0f;
    private float curTimeWalking = 0f;
    private float timeWalking = 2f; //how long I want him to walk for
    private bool doneWalking = false; //flag to check if finished walk animation

    private float curTimeShooting = 0f;
    private float timeShooting = 2f; //how long I want him to shoot for
    private bool doneShooting = false;

    //enemies
    public GameObject enemy0;
    public GameObject enemy00;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = dialogue.GetComponent<DialogueManager>();
        animationController = wordBot.GetComponent<animationController>();
        wbg = botGun.GetComponent<WordBotGun>();
        curScript = dialogueManager.curIdx;
        botRB = botAndGun.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //checks which sentence we're on
        curScript = dialogueManager.curIdx;
        Debug.Log(curScript);
        Debug.Log(curPlaying);

        //checks which animation scene to play
        if ((curScript == 0) && (curPlaying != 0))
        {
            curPlaying = 0;
        }
        else if ((curScript == 1) && (curPlaying != 1))
        {
            curPlaying = 1;
        }
        //tries shooting enemy0 and fails
        else if ((curScript == 2))
        {
            curPlaying = 2;

            Debug.Log("tried to rotate!");
            float speed = 100f;

            RaycastHit hit;
            //transform.right since the robot's red arrow points forward
            if (Physics.Raycast(botAndGun.transform.position, botAndGun.transform.right, out hit))
            {
                if (hit.transform.name != enemy0.name)
                {
                    botAndGun.transform.Rotate(Vector3.up * speed * Time.deltaTime);
                    
                }
                else //pointing at the enemy
                {
                    Debug.Log("found enemy!!!");

                    //shoot that dude
                    lastShot += Time.deltaTime;
                    //shoot every second
                    if (lastShot >= 1f)
                    {
                        lastShot = 0f;
                        wbg.Shoot();
                        Debug.Log("GOTEEEEM!");
                    }
                }
            }
        }
        //shoots correct enemy00
        else if (curScript == 3)
        {
            

            //turn wordBot towards the other enemy
            float speed = 100f;

            RaycastHit hit;
            //transform.right since the robot's red arrow points forward
            if (Physics.Raycast(botAndGun.transform.position, botAndGun.transform.right, out hit))
            {
                if (hit.transform.name != enemy00.name)
                {
                    botAndGun.transform.Rotate(Vector3.down * speed * Time.deltaTime);

                }
                else //pointing at the enemy
                {
                    Debug.Log("found enemy!!!");
                    curPlaying = 3;

                    //walk and shoot enemy
                    
                    Debug.Log("Cur Time walking is:" + curTimeWalking);
                    if (curTimeWalking < timeWalking) //still walking
                    {
                        Debug.Log("Started Walking");
                        curTimeWalking += Time.deltaTime;

                        //moves bot forward by speed
                        float walkSpeed = 1f;
                        //change velocity if not yet
                        if (!animationController.isWalking)
                        {
                            animationController.startWalking();
                            botRB.velocity = botAndGun.transform.right * walkSpeed;
                        }

                    }
                    else if ((curTimeWalking >= timeWalking) && !doneWalking) //finished walking
                    {
                        botRB.velocity = new Vector3(0, 0, 0);
                        animationController.stopWalking();
                        doneWalking = true;
                        Debug.Log("finished walking");
                    }


                    else if ((curTimeShooting < timeShooting) && doneWalking && !doneShooting) //only shoots after he walks
                    {
                        Debug.Log("started shooting");
                        curTimeShooting += Time.deltaTime;
                        //shoot that dude
                        lastShot += Time.deltaTime;
                        //shoot every second
                        if (lastShot >= 1f)
                        {
                            lastShot = 0f;
                            //wbg.Shoot(); //sneaky sneaky
                            if (enemy00 != null) //is enemy still alive?
                            {
                                Health health = enemy00.GetComponent<Health>();
                                if (health != null)
                                {
                                    health.TakeDamage(50, wordBot);
                                    Debug.Log("getting bopped");
                                }
                                else
                                {
                                    Debug.Log("not getting bopped :(");
                                }
                            }
                            

                        }
                    }
                    else // finished shooting
                    {
                        doneShooting = true;
                        Debug.Log("finished walk and shoot");
                    }
                    


                }
            }


        }
        else if ((curScript == 4) && (curPlaying != 4))
        {
            curPlaying = 4;
        }
        else if ((curScript == 5) && (curPlaying != 5))
        {
            curPlaying = 5;
        }

    }

    void walkAndShoot(float timeWalking, float timeShooting)
    {
        float curTime = 0f;

        

        while (curTime < timeWalking)
        {
            Debug.Log("Started Walking");
            curTime += Time.deltaTime;
            animationController.startWalking();
            //moves bot forward by speed
            float speed = 1f;
            botRB.velocity = botAndGun.transform.right * speed;
        }
        botRB.velocity = new Vector3(0, 0, 0);
        animationController.stopWalking();
        curTime = 0f;

        while (curTime < timeShooting)
        {
            Debug.Log("started shooting");
            curTime += Time.deltaTime;
            //shoot that dude
            lastShot += Time.deltaTime;
            //shoot every second
            if (lastShot >= 0.5f)
            {
                lastShot = 0f;
                wbg.Shoot();
                
            }
        }
        Debug.Log("finished walk and shoot");

        
    }


}
