using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour
{
    Animator animator;
    public bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void startWalking()
    {
        animator.SetBool("isWalking", true);
        isWalking = true;
    }
    public void stopWalking()
    {
        animator.SetBool("isWalking", false);
        isWalking = false;
    }
}
