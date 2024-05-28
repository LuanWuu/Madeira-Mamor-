using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCharacters : MonoBehaviour
{
    [SerializeField] private GameObject[] Assis;
    [SerializeField] private GameObject[] Solon;
    [SerializeField] private GameObject[] Emanuel;
    [SerializeField] private GameObject[] Antonio;
    [SerializeField] private GameObject[] Raimundo;
    public void DisableDia4(){//4 Dia 20
        for(int i = 0; i < 3; i++) {
            Solon[i].SetActive(false);
            Emanuel[i].SetActive(false);
            Antonio[i].SetActive(true);
        }
    }
    public void DisableDia5(){//5 Dia 22
        for(int i = 0; i < 3; i++) {
            Raimundo[i].SetActive(false);;
        }
    }
    public void DisableDia6(){//6 dia 25
        for(int i = 0; i < 3; i++) {
            Assis[i].SetActive(false);
        }
    }
}
