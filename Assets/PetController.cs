using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{

    public Transform playerTarget;
    public float speedPet;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerTarget.position, speedPet * Time.deltaTime);
    }
}
