using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    [SerializeField] private Animator AxeAnimator;
    [SerializeField] private HammerMinigame hammerScript;
    void HitWood(){
        hammerScript.ChangeScript();
    }
    void Reset() {
        AxeAnimator.SetBool("AxeCut",false);
    }
}
