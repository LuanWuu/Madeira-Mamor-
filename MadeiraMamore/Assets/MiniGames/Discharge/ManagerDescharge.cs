using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDescharge : MonoBehaviour
{
    [SerializeField] private DeschargeMinigame[] DescharMiniScricpt;
    public void StartMinigame(){
        for(int i = 0; i < DescharMiniScricpt.Length; i++) {
            DescharMiniScricpt[i].CreateBoxs();
        }
    }
}
