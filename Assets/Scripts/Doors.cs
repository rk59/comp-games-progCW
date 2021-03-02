using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    Animator doorAnimator;
    bool doorOpen;

    private void Start()
    {
        doorOpen = false;
        doorAnimator = GetComponent<Animator>();

    }

    void OnTriggerEnter(Collider near)
    {
        if(near.gameObject.tag == "Player")
        {
            doorOpen = true;
            DoorOp("Open");
        }
    }

   void OnTriggerExit(Collider near)
    {
        if (doorOpen)
        {
            doorOpen = false;
            DoorOp("Close");
        }
    }

    void DoorOp(string process)
    {
        doorAnimator.SetTrigger(process);
    }
        
        
}
