using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBallZone : MonoBehaviour
{
    private void Start()
    {
        Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(), GetComponent<Collider>());
    }


}