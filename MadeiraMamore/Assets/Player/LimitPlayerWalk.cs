using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitPlayerWalk : MonoBehaviour
{
    [SerializeField] private MensageController mensageControllerScript;
    [SerializeField] private GameObject Cururu;
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "player") {
            mensageControllerScript.LimitBarrier();
            Cururu.SetActive(true);
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "player") {
            Cururu.SetActive(false);
        }
    }
}
