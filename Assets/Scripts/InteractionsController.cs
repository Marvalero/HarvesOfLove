using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsController : MonoBehaviour
{
    public bool nextWasClicked = false;

    public bool WasNextPressedThisFrame()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!nextWasClicked)
            {
                nextWasClicked = true;
                return true;
            }
        }
        else
        {
            nextWasClicked = false;
        }
        return false;
    }
}
