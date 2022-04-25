using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    //Game Objects
    public GameObject player;
    public GameObject tutorialObject;
    public GameObject botAndGun;

    //scripts to load
    private animationController animationController;
    private Tutorial tutorial;

    //variables to modify
    private float TargetDistance;
    public float AllowedDistance;
    public float FollowSpeed;
    public RaycastHit Shot;
    private bool isWalking = false;


    private void Start()
    {
        tutorial = tutorialObject.GetComponent<Tutorial>();
        animationController = GetComponent<animationController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorial.isTutorialDone) //will only follow once tutorial is complete
        {
            Debug.Log("started following player");
            botAndGun.transform.LookAt(player.transform);
            //need to rotate him 3 times to set forward correctly
            for (int i = 0; i < 3; i++)
            {
                botAndGun.transform.forward = botAndGun.transform.right;
            }

            if (Physics.Raycast(botAndGun.transform.position, botAndGun.transform.TransformDirection(Vector3.forward), out Shot))
            {
                TargetDistance = Shot.distance;
                if (TargetDistance >= AllowedDistance)
                {
                    Debug.Log("Tryna walk");
                    if (!isWalking) //flag to stop repitive calls
                    {
                        isWalking = true;
                        animationController.startWalking();
                    }

                    botAndGun.transform.position = Vector3.MoveTowards(botAndGun.transform.position, player.transform.position, FollowSpeed);
                }
            }
            else
            {
                if (isWalking) //stops repititve calls
                {
                    isWalking = false;
                    animationController.stopWalking();
                }

            }



        }
        
        
    }
}
