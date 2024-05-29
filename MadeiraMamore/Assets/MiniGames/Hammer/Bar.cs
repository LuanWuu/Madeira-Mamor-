using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    [SerializeField] private HammerMinigame hammerScript;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Pointer") {
            hammerScript.canCut = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Pointer") {
            hammerScript.canCut = false;
        }
    }
}
