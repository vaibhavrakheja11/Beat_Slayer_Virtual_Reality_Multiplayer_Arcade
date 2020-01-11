using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        { //movement forward
            if (Input.GetKeyDown(KeyCode.W) || OVRInput.GetDown(OVRInput.Button.DpadUp))
            {

                animator.SetBool("runForward", true);

            }
            else if (Input.GetKeyUp(KeyCode.W))
            {

                animator.SetBool("runForward", false);

            }
        }
        { //movement backward
            if (Input.GetKeyDown(KeyCode.S))
            {
                
                    animator.SetBool("runBackward", true);
                
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
               
                    animator.SetBool("runBackward", false);
                
            }
        }
        //{ //movement crouch
        //    if (Input.GetKeyDown(KeyCode.LeftControl))
        //    {
        //        if (photonView.IsMine)
        //        {
        //            animator.SetBool("isCrouch", true);
        //        }
        //    }
        //    else if (Input.GetKeyUp(KeyCode.LeftControl))
        //    {
        //        if (photonView.IsMine)
        //        {
        //            animator.SetBool("isCrouch", false);
        //        }
        //    }
        //}
        { //movement Jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
               
                    animator.SetBool("jump", true);
                
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                
                    animator.SetBool("jump", false);
                
            }
        }
        //{ //movement run Right
        //    if (Input.GetKeyDown(KeyCode.D))
        //    {
        //        if (photonView.IsMine)
        //        {
        //            animator.SetBool("isRunningRight", true);
        //        }
        //    }
        //    else if (Input.GetKeyUp(KeyCode.D))
        //    {
        //        if (photonView.IsMine)
        //        {
        //            animator.SetBool("isRunningRight", false);
        //        }
        //    }
        //}
        //{//movement run Right
        //    if (Input.GetKeyDown(KeyCode.A))
        //    {
        //        if (photonView.IsMine)
        //        {
        //            animator.SetBool("isRunningLeft", true);
        //        }
        //    }
        //    else if (Input.GetKeyUp(KeyCode.A))
        //    {
        //        if (photonView.IsMine)

        //        {
        //            animator.SetBool("isRunningLeft", false);
        //        }
        //    }
        //}

    }




}
