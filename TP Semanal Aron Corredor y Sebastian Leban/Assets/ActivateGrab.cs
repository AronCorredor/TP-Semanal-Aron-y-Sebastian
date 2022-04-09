using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGrab : MonoBehaviour
{
    //Grabbing
    public static bool staticPlayerGrabbing = false; // TO DO: Se tiene que cambiar para 2 players
    private bool CanGrab;

    // Update is called once per frame
    void Update()
    {
        //Agarrar
        if (Input.GetMouseButtonDown(1) && PlayerControl.ballAmmoCount == 0)
        {
            StartCoroutine("BallGrab");
            Debug.Log("coroutine");
        }
    }

    IEnumerator BallGrab()
    {
        CanGrab = false;
        staticPlayerGrabbing = true;
        yield return new WaitForSeconds(.4f);
        Debug.Log("Grab Desactivado");
        staticPlayerGrabbing = false;
        yield return new WaitForSeconds(.9f);
        CanGrab = true;
        Debug.Log("Podes volver a agarrar");
    }
}
