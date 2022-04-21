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

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = dialogue.GetComponent<DialogueManager>();
        animationController = wordBot.GetComponent<animationController>();
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
            playScene0();
        }
        else if ((curScript == 1) && (curPlaying != 1))
        {
            curPlaying = 1;
            playScene1();
        }
        else if ((curScript == 2))
        {
            curPlaying = 2;

            Debug.Log("tried to rotate!");
            float speed = 50f;
            while (botAndGun.transform.rotation.y != 300f)
            {
                botAndGun.transform.Rotate(Vector3.up * speed * Time.deltaTime);
                Debug.Log(botAndGun.transform.rotation);
            }
            

            //playScene2();
        }
        else if ((curScript == 3) && (curPlaying != 3))
        {
            curPlaying = 3;
            playScene3();
        }
        else if ((curScript == 4) && (curPlaying != 4))
        {
            curPlaying = 4;
            playScene4();
        }
        else if ((curScript == 5) && (curPlaying != 5))
        {
            curPlaying = 5;
            playScene5();
        }

    }


    //all different scenes
    void playScene0()
    {

    }
    void playScene1()
    {

    }
    //tries shooting enemy0 and fails
    void playScene2()
    {
        
        

    }
    void playScene3()
    {

    }
    void playScene4()
    {

    }
    void playScene5()
    {

    }
}