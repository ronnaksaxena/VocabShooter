using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;
using TMPro;

public class tutorial3 : MonoBehaviour
{
    //to control wordBot Dialogue
    public GameObject dialogue;
    private DialogueManager dialogueManager;
    private int curScript; //which script we're on

    //to control wordBot movement
    public GameObject botAndGun;
    public GameObject wordBot;
    private animationController animationController;
    public GameObject botGun;
    private WordBotGun wbg;
    private Rigidbody botRB;


    public bool isTutorialDone = false;



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
            if (curScript == 0)
            {

            }
            else if (curScript == 1)
            {

            }
            else if (curScript == 2) //done playing
            {
                isTutorialDone = true;
            }


        }




    }




}
