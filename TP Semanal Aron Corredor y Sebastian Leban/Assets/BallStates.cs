using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStates : MonoBehaviour
{

    //Bools
    bool onFloor = false;
    bool isAttacking;
    bool isRedTeam;

    void Start()
    {
    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //Convierte a la pelote en Neutral
        if (other.tag == "Map")
        {
            onFloor = true;
        }

        //Agarra el jugador
        if (other.tag == "Player" && onFloor || other.tag == "Player" && PlayerControl.staticPlayerGrabbing)
        {
            Destroy(gameObject);
            PlayerControl.ballAmmoCount++;
            Debug.Log("agarro pelota");
        }

        //Lastima jugador
        if (other.tag == "Player" && !onFloor)
        {
            Debug.Log("Player recibe Hit");
        }

    }
}
