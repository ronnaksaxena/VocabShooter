using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;
using TMPro;

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
    public bool isTutorialDone = false;

    //enemies
    public GameObject enemy0;
    public GameObject enemy00;
    public TextMeshProUGUI e0Text; //to change e0 text after e00 dies

    //player
    public GameObject player;

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

        //only run this if tutorial is going on
        if (!isTutorialDone)
        {
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

                        //shoot that dude
                        lastShot += Time.deltaTime;
                        //shoot every second
                        if (lastShot >= 1f)
                        {
                            lastShot = 0f;
                            wbg.Shoot();
                        }
                    }
                }
            }
            //shoots correct enemy00 until he dies
            else if ((curScript == 3) && (enemy00 != null))
            {


                //turn wordBot towards the other enemy
                float speed = 50f;

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
                        curPlaying = 3;
                        Debug.Log("Rotation is " + botAndGun.transform.rotation);

                        //walk and shoot enemy

                        if (curTimeWalking < timeWalking) //still walking
                        {
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
                        }


                        else if ((curTimeShooting < timeShooting) && doneWalking && !doneShooting) //only shoots after he walks
                        {
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
                        }



                    }
                }


            }
            else if ((curScript == 4) && (enemy0 != null)) //shoot the enemy0 until he dies
            {
                Debug.Log("entered script 4");
                //make enemy0 shootable
                Health e0health = enemy0.GetComponent<Health>();
                e0health.setInvincible(false);
                e0Text.SetText("Mammoth");
                //turn wordBot towards the other enemy
                float speed = 100f;

                RaycastHit hit;
                //transform.right since the robot's red arrow points forward
                if (Physics.Raycast(botAndGun.transform.position, botAndGun.transform.right, out hit))
                {
                    if (hit.transform.name != enemy0.name)
                    {
                        botAndGun.transform.Rotate(Vector3.up * speed * Time.deltaTime);

                    }
                    else
                    {
                        //shoot enemy0
                        lastShot += Time.deltaTime;
                        //shoot every second
                        if (lastShot >= 1f)
                        {
                            lastShot = 0f;
                            //wbg.Shoot(); //sneaky sneaky
                            if (enemy0 != null) //is enemy still alive?
                            {
                                if (e0health != null)
                                {
                                    e0health.TakeDamage(50, wordBot);
                                }
                                else
                                {
                                    Debug.Log("not getting bopped :(");
                                }
                            }


                        }

                    }

                }
            }
            else if (curScript == 5)
            {
                Debug.Log("entered script 5");
                //turn wordBot towards the other player
                float speed = 200f;

                RaycastHit hit;
                //transform.right since the robot's red arrow points forward
                if (Physics.Raycast(botAndGun.transform.position, botAndGun.transform.right, out hit))
                {
                    if (hit.transform.name != player.name)
                    {
                        botAndGun.transform.Rotate(Vector3.down * speed * Time.deltaTime);

                    }
                    else //looking at player so tutotial is done
                    {
                        Debug.Log("finished script");
                        isTutorialDone = true;

                    }


                }
            }

        }

        


    }




}
