using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanger : MonoBehaviour
{
    public GameObject Sprinter;
    public GameObject Jumper;
    public GameObject Pouncer;

    public Vector3 Spawn;

    private void OnTriggerEnter(Collider other)   //When tag hits collider change to next sub-class in que
    {
        if(other.tag == "Sprinter"){
        Sprinter.SetActive(false);
        Jumper.transform.position = Spawn;
        Jumper.SetActive(true);

        Debug.Log("Jumper is now Active");
        }
        
        if(other.tag == "Jumper"){
        Jumper.SetActive(false);
        Pouncer.transform.position = Spawn;
        Pouncer.SetActive(true);
        
        Debug.Log("Pouncer is now Active");
        }

        if(other.tag == "Pouncer"){
        Pouncer.SetActive(false);
        Sprinter.transform.position = Spawn;
        Sprinter.SetActive(true);

        Debug.Log("Sprinter is now Active");
        }

    }










}
