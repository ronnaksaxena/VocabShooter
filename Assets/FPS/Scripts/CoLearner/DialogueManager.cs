using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //objects to delete after tutotial is over
    public Text botName;
    public Text continueLabel;
    public GameObject background;


    public Text script;
    public DialogueTrigger dialogueTrigger;

    //to stop user from clicking continue too fast
    float timePassed = 0f;



    // Start is called before the first frame update
    void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        script.text = dialogueTrigger.curText;
        
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
        if (Input.GetKey("x") && (timePassed >= 5f))
        {
            //more sentences left
            if (!dialogueTrigger.isScriptOver())
            {
                timePassed = 0f;
                script.text = dialogueTrigger.getNextSentence();
            }
            else //reached end of script
            {
                botName.enabled = false;
                continueLabel.enabled = false;
                script.enabled = false;
                background.SetActive(false);
            }
            
        }
    }

}
