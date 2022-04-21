using System.Collections;
using System.Collections.Generic;
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
    float lastShot = 0f;

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
            float speed = 50f;

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
        else if ((curScript == 3) && (curPlaying != 3))
        {
            curPlaying = 3;
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


}
