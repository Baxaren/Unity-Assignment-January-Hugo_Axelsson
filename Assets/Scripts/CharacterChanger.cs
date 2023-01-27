using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanger : MonoBehaviour
{
    public GameObject Sprinter;
    public GameObject Jumper;
    public GameObject Pouncer;

    public Vector3 Spawn;

    private void OnTriggerEnter(Collider other)   //When tagged gameobject hits collider change to next sub-class in queue
    {
        if(other.tag == "Sprinter"){    //Disable Sprinter, Reset Jumper to Spawn, then Enable Jumper
        Sprinter.SetActive(false);
        Jumper.transform.position = Spawn;
        Jumper.SetActive(true);

        Debug.Log("Jumper is now Active");
        }
        
        if(other.tag == "Jumper"){    //Disable Jumper, Reset Pouncer to Spawn, then Enable Pouncer
        Jumper.SetActive(false);
        Pouncer.transform.position = Spawn;
        Pouncer.SetActive(true);
        
        Debug.Log("Pouncer is now Active");
        }

        if(other.tag == "Pouncer"){    //Disable Pouncer, Reset Sprinter to Spawn, then Enable Sprinter
        Pouncer.SetActive(false);
        Sprinter.transform.position = Spawn;
        Sprinter.SetActive(true);

        Debug.Log("Sprinter is now Active");
        }

    }










}
