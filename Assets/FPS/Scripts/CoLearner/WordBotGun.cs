using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Timers;
using Unity.FPS.Game;
using UnityEngine.AI;
using UnityEngine.Events;

public class WordBotGun : MonoBehaviour
{
    public float damage = 0f;
    public float range = 100f;



    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("j")) //Change later!!
        {
            Shoot();
        }
        
    }

    //shooting method
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }

    }
}
