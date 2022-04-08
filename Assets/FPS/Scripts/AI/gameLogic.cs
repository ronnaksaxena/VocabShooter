using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TextMeshProUGUI; //package not showing up, need assembly reference?
//https://stackoverflow.com/questions/61102508/tmpro-not-found-in-visual-studio-code

using TMPro;

public class gameLogic : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject Boss;
    public GameObject e1Text;
    public GameObject e2Text;
    public TextMeshProUGUI e3Text;
    public GameObject BossText;
    // Start is called before the first frame update
    void Start()
    {
        e3Text = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        if (enemy2 == null)
            e3Text.text = "Gargantuan";
        {
        }

    }
}
