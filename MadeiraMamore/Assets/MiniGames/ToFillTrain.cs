using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToFillTrain : MonoBehaviour
{
    [SerializeField] private GameObject fulfilling;
    private GameObject[] boxFulfilling;
    private int turn = 0;
    // Start is called before the first frame update
    void Start()
    {
        boxFulfilling = new GameObject[fulfilling.transform.childCount];
        for (int i = 0; i < fulfilling.transform.childCount; i++)
        {
            boxFulfilling[i]= fulfilling.transform.GetChild(i).gameObject;
        }
        Debug.Log(boxFulfilling.Length);
    }
    public void FillTheLoad () {
        //Debug.Log(" delivery " + delivery);
        turn++;
        if(turn < boxFulfilling.Length){ 
            for (int i = 0; i < turn; i++)
            {
                boxFulfilling[i].SetActive(true);
                Debug.Log(" turn " + i);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
