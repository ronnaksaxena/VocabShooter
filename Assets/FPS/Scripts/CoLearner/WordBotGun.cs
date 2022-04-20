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

    public GameObject wordBot;



    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("j")) //escape key to test shooting Change later!!
        {
            Shoot();
        }
        
    }

    //shooting method
    void Shoot()
    {
        RaycastHit hit;

        //need to manipulate direction since the gun is rotated the wrong way
        Vector3 newForward = transform.forward;
        newForward.z += 1f;
        newForward.x += 1f;

        if (Physics.Raycast(transform.position, newForward, out hit, range))
        {

            Health health = hit.transform.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage, wordBot);
            }
            else
            {
                Debug.Log("health not found");
            }
        }

    }
}
