using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [TextArea(3, 10)]
    public string[] dialogue;
    public int curIdx = 0;
    public string curText = "";


    private void Start()
    {
        if (dialogue.Length > 0) { curText = dialogue[curIdx]; };
    }

    public string getNextSentence()
    {
        Debug.Assert(curIdx < dialogue.Length);
        curIdx += 1;
        curText = dialogue[curIdx];
        return dialogue[curIdx];
    }

    public bool isScriptOver()
    {
        return (curIdx == dialogue.Length-1);
    }
}
