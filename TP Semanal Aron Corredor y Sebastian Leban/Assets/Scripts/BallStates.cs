using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStates : MonoBehaviour
{

    //Bools
    bool onFloor = false;
    bool isAttacking;
    bool isRedTeam;

    //TempFix Ataque
    bool playerHasThrownBall = false;

    //DMG y Knockback
    private float force = 5;


    void Update()
    {

        //Remueve el trail de a poquito
        if (onFloor)
        {
            gameObject.GetComponent<TrailRenderer>().time -= 0.001f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //Convierte a la pelote en Neutral
        if (other.tag == "Map")
        {
            onFloor = true;
        }

        //Agarra el jugador
        if (other.tag == "Player" && onFloor)
        {
            AddBall();
        }

        //Hit enemigo
        if (other.tag == "Player" && !onFloor && playerHasThrownBall == true)
        {
            //Knockback
            Vector3 pushDirection = other.transform.position - transform.position;
            pushDirection = -pushDirection.normalized;
            other.GetComponent<Rigidbody>().AddForce(pushDirection * (force * PlayerControl.PlayerKnockback) * -100);
            PlayerControl.PlayerKnockback += 1;
        }

        //Temp Fix al problema de que colisione con el jugador que tira la pelota
        else if (other.tag == "Player" && !onFloor)
        {
            playerHasThrownBall = true;
        }

        //Grab Aereo
        if (other.tag == "GrabArea" && ActivateGrab.staticPlayerGrabbing)
        {
            AddBall();
        }


    }

    private void AddBall()
    {
        Destroy(gameObject);
        PlayerControl.ballAmmoCount++;
        Debug.Log("agarro pelota");
    }
}
