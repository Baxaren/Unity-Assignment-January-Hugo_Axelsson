using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanger : MonoBehaviour
{
    public GameObject sprinter;

    public GameObject Jumper;

    public GameObject Pouncer;


    private void OnTriggerEnter(Collider other)
    {
        sprinter.SetActive(true);
        Debug.Log("Sprinter is Active");
    }










}
